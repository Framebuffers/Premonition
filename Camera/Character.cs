using Godot;
using Premonition.Camera.Debug;
using Premonition.Managers;


namespace Premonition.Camera
{
    public partial class Character : CharacterBody3D
    {
        private GameDirector _director => this.GetGameDirector();

        private readonly float baseSpeed = 3.0f;
        private readonly float sprintSpeed = 6.0f;
        private readonly float crouchSpeed = 1.0f;
        private readonly float acceleration = 3.0f;
        private readonly float jumpVelocity = 4.5f;
        private readonly float mouseSensitivity = 0.005f;
        private readonly bool immobile = false;

        //[Export(PropertyHint.File)]
        //public string defaultReticle;

        private Vector3 initial_facing_direction = Vector3.Zero;

        private Node3D HEAD => GetNode<Node3D>("Head");

        private Camera3D CAMERA => GetNode<Camera3D>("Head/Camera");

        private AnimationPlayer HEADBOB_ANIMATION => GetNode<AnimationPlayer>("Head/HeadbobAnimation");

        private AnimationPlayer JUMP_ANIMATION => GetNode<AnimationPlayer>("Head/JumpAnimation");

        private AnimationPlayer CROUCH_ANIMATION => GetNode<AnimationPlayer>("CrouchAnimation");

        private CollisionShape3D COLLISION_MESH => GetNode<CollisionShape3D>("Collision");

        private ShapeCast3D CEILING_DETECTION => GetNode<ShapeCast3D>("CrouchCeilingDetection");


        private readonly string JUMP = "jump";
        private readonly string LEFT = "move_left";
        private readonly string RIGHT = "move_right";
        private readonly string FORWARD = "move_forward";
        private readonly string BACKWARD = "move_back";
        private readonly string PAUSE = "pause";
        private readonly string CROUCH = "crouch";
        private readonly string SPRINT = "sprint";
        private readonly bool jumpingEnabled = false;
        private readonly bool inAirMomentum = false;
        private readonly bool motionSmoothing = true;
        private readonly bool sprintEnabled = false;
        private readonly bool crouchEnabled = false;

        public int crouchMode = 0;
        public int sprintMode = 0;
        private readonly bool dynamicFOV = true;
        private readonly bool continuousJumping = false;
        private readonly bool viewBobbing = true;
        private readonly bool jumpAnimation = false;

        // Member variables
        private float speed;
        private float currentSpeed = 0.0f;

        // States: normal, crouching, sprinting
        private string state = "normal";
        private bool lowCeiling = false; // This is for when the ceiling is too low and the player needs to crouch.
        private bool wasOnFloor = true;
        private Reticle RETICLE;

        private Control USER_INTERFACE => _director.ScreenManager.UserInterface;

        private DebugPanel DEBUG_PANEL => _director.ScreenManager.DebugPanel;

        // Get the gravity from the project settings to be synced with RigidBody nodes.
        public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
        // Updates mouse look

        public float sensitivity = 0.25f;

        // Mouse state
        private Vector2 _mouse_position = new Vector2(0.0f, 0.0f);
        private float _total_pitch = 0.0f;
        private void _update_mouselook()
        {
            // Only rotates mouse if the mouse is 
            if (Input.MouseMode == Input.MouseModeEnum.Captured)
            {
                _mouse_position *= sensitivity;
                float yaw = _mouse_position.X;
                float pitch = _mouse_position.Y;
                _mouse_position = Vector2.Zero;

                // Prevents looking up/down too far
                pitch = Mathf.Clamp(pitch, -90 - _total_pitch, 90 - _total_pitch);
                _total_pitch += pitch;

                RotateY(Mathf.DegToRad(-yaw));
                RotateObjectLocal(new Vector3(1.0f, 0.0f, 0.0f), Mathf.DegToRad(-pitch));
            }
        }

        public override void _Ready()
        {
            base._Ready();
            speed = baseSpeed;
            Input.MouseMode = Input.MouseModeEnum.Captured;

            // Set the camera rotation to whatever initial_facing_direction is, as long as it's not Vector3.zero
            if (!initial_facing_direction.Equals(Vector3.Zero))
            {
                HEAD.RotationDegrees = initial_facing_direction;
            }

            //if (defaultReticle != null)
            //{
            //	change_reticle(defaultReticle);
            //}

            HEADBOB_ANIMATION.Play("RESET");
            JUMP_ANIMATION.Play("RESET");
            CROUCH_ANIMATION.Play("RESET");
        }

        private void change_reticle(string reticlePath)
        {
            RETICLE?.QueueFree();
            _director.ScreenManager.AddToScreen2D(reticlePath, out RETICLE);
            RETICLE.character = this;
        }

        public override void _PhysicsProcess(double delta)
        {
            currentSpeed = Vector3.Zero.DistanceTo(GetRealVelocity());

            // _director.ScreenManager.DebugPanel.AddProperty("Speed", $"{currentSpeed:0.000}", 1);
            // _director.ScreenManager.DebugPanel.AddProperty("Target Speed", $"{speed}", 2);
            Vector3 cv = GetRealVelocity();
            // _director.ScreenManager.DebugPanel.AddProperty("Velocity", $"X: {cv.X:0.000} Y: {cv.Y:0.000} X: {cv.X:0.000}", 3);

            // Gravity
            //  If the gravity changes during your game, uncomment this code
            // gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
            HandleGravityAndJumping(delta);

            Vector2 inputDir = immobile ? Vector2.Zero : Input.GetVector(LEFT, RIGHT, FORWARD, BACKWARD);
            HandleMovement(delta, inputDir);

            lowCeiling = CEILING_DETECTION.IsColliding();
            HandleState(inputDir != Vector2.Zero);

            if (dynamicFOV) { UpdateCameraFOV(); }

            if (viewBobbing) { HeadbobAnimation(inputDir != Vector2.Zero); }

            if (jumpAnimation)
            {
                if (!wasOnFloor && IsOnFloor()) // Just Landed
                {
                    JUMP_ANIMATION.Play((GD.Randi() % 2) == 1 ? "land_left" : "land_right");
                }
                wasOnFloor = IsOnFloor(); //This must always be at the end of physics_process
            }
        }

        private void HandleGravityAndJumping(double delta)
        {
            Vector3 currentVelocity = Velocity;
            if (!IsOnFloor())
            {
                currentVelocity.Y -= (float)(gravity * delta);
            }

            else if (jumpingEnabled)
            {
                if (continuousJumping ? Input.IsActionPressed(JUMP) : Input.IsActionJustPressed(JUMP))
                {
                    if (IsOnFloor() && !lowCeiling)
                    {
                        if (JUMP_ANIMATION != null)
                        {
                            JUMP_ANIMATION.Play("jump");
                        }
                        currentVelocity.Y += jumpVelocity;
                    }
                }
            }
            Velocity = currentVelocity;
        }

        private void HandleMovement(double delta, Vector2 inputDir)
        {
            Vector2 direction2D = inputDir.Rotated(-HEAD.Rotation.Y);
            Vector3 direction = new Vector3(direction2D.X, 0, direction2D.Y);
            direction = direction.Normalized(); // ?
            MoveAndSlide();

            if (!inAirMomentum || IsOnFloor())
            {
                Vector3 currentVelocity = Vector3.Zero;
                currentVelocity.X = motionSmoothing ? Mathf.Lerp(Velocity.X, direction.X * speed, (float)(acceleration * delta)) : direction.X * speed;
                currentVelocity.Z = motionSmoothing ? Mathf.Lerp(Velocity.Z, direction.Z * speed, (float)(acceleration * delta)) : direction.Z * speed;
                Velocity = currentVelocity;
            }
        }

        private void HandleState(bool moving)
        {
            if (sprintEnabled)
            {
                switch (sprintMode)
                {
                    case 0:
                        if (Input.IsActionPressed(SPRINT) && state != "crouching")
                        {
                            if (moving)
                            {
                                if (state != "sprinting")
                                {
                                    EnterSprintState();
                                }
                            }
                            else
                            {
                                if (state == "sprinting")
                                {
                                    EnterNormalState();
                                }
                            }
                        }
                        else if (state == "sprinting")
                        {
                            EnterNormalState();
                        }
                        break;
                    case 1:
                        if (moving)
                        {
                            if (Input.IsActionPressed(SPRINT) && state == "normal")
                            {
                                EnterSprintState();
                            }
                            if (Input.IsActionJustPressed(SPRINT))
                            {
                                switch (state)
                                {
                                    case "normal":
                                        EnterSprintState();
                                        break;
                                    case "sprinting":
                                    default:
                                        EnterNormalState();
                                        break;
                                }
                            }
                        }
                        else if (state == "sprinting")
                        {
                            EnterNormalState();
                        }
                        break;
                }
            }

            if (crouchEnabled)
            {
                switch (crouchMode)
                {
                    case 0:
                        if (Input.IsActionPressed(CROUCH) && state != "sprinting")
                        {
                            if (state != "crouching")
                            {
                                enterCrouchState();
                            }
                        }
                        else if (state == "crouching" && !CEILING_DETECTION.IsColliding())
                        {
                            EnterNormalState();
                        }
                        break;
                    case 1:
                        if (Input.IsActionJustPressed(CROUCH))
                        {
                            switch (state)
                            {
                                case "normal":
                                    enterCrouchState();
                                    break;
                                case "crouching":
                                default:
                                    if (!CEILING_DETECTION.IsColliding())
                                    {
                                        EnterNormalState();
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        private void EnterNormalState()
        {
            string previousState = state;
            if (previousState == "crouching") CROUCH_ANIMATION.PlayBackwards("crouch");
            state = "normal";
            speed = baseSpeed;
        }

        private void EnterSprintState()
        {
            string previousState = state;
            if (previousState == "crouching") CROUCH_ANIMATION.PlayBackwards("crouch");
            state = "sprinting";
            speed = sprintSpeed;
        }

        private void enterCrouchState()
        {
            string previousState = state;
            state = "crouching";
            speed = crouchSpeed;
            CROUCH_ANIMATION.Play("crouch");
        }

        private void UpdateCameraFOV()
        {
            CAMERA.Fov = Mathf.Lerp(CAMERA.Fov, state == "sprinting" ? 85 : 75, 0.3f);
        }

        private void HeadbobAnimation(bool moving)
        {
            if (moving && IsOnFloor())
            {
                string useHeadbobAnimation = (state == "normal" || state == "crouching") ? "walk" : "sprint";
                bool wasPlaying = HEADBOB_ANIMATION.CurrentAnimation == useHeadbobAnimation;

                HEADBOB_ANIMATION.Play(useHeadbobAnimation, 0.25f);
                HEADBOB_ANIMATION.SpeedScale = (currentSpeed / baseSpeed) * 1.75f;
                if (!wasPlaying) { HEADBOB_ANIMATION.Seek((double)(GD.Randi() % 2)); }
            }
            else
            {
                HEADBOB_ANIMATION.Play("RESET", 0.25);
                HEADBOB_ANIMATION.SpeedScale = 1;
            }
        }

        public override void _Process(double delta)
        {
            // _director.ScreenManager.DebugPanel.AddProperty("FPS", $"{Performance.GetMonitor(Performance.Monitor.TimeFps)}", 0);
            // _director.ScreenManager.DebugPanel.AddProperty("state", $"{state}" + (!IsOnFloor() ? " in the air" : ""), 4);
            if (Input.IsActionJustPressed(PAUSE))
            {
                Input.MouseMode = (Input.MouseMode == Input.MouseModeEnum.Captured) ? Input.MouseModeEnum.Visible : Input.MouseModeEnum.Captured;
            }
            _update_mouselook();
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventMouseMotion && Input.MouseMode == Input.MouseModeEnum.Captured)
            {
                InputEventMouseMotion iemm = (InputEventMouseMotion)@event;
                Vector3 currentRotation = HEAD.Rotation;
                currentRotation.Y -= iemm.Relative.X * mouseSensitivity;
                currentRotation.X -= iemm.Relative.Y * mouseSensitivity;
                HEAD.Rotation = currentRotation;
            }
        }
    }

}
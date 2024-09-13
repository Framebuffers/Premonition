using Godot;
using Premonition.Managers;
using System;
using Premonition.Camera.Debug;
using System.Linq;


namespace Premonition.Camera
{
	public partial class Character : CharacterBody3D
	{
		private GameDirector _director { get => this.GetGameDirector(); }
		[ExportCategory("Character")]
		[Export]
		float baseSpeed = 3.0f;
		[Export]
		float sprintSpeed = 6.0f;
		[Export]
		float crouchSpeed = 1.0f;

		[Export]
		float acceleration = 10.0f;
		[Export]
		float jumpVelocity = 4.5f;
		[Export]
		float mouseSensitivity = 0.005f;
		[Export]
		bool immobile = false;
		[Export(PropertyHint.File)]
		public string defaultReticle;
		[Export]
		Vector3 initial_facing_direction = Vector3.Zero;

		[ExportGroup("Nodes")]
		[Export]
		Node3D HEAD;
		[Export]
		Camera3D CAMERA;
		[Export]
		AnimationPlayer HEADBOB_ANIMATION;
		[Export]
		AnimationPlayer JUMP_ANIMATION;
		[Export]
		AnimationPlayer CROUCH_ANIMATION;
		[Export]
		CollisionShape3D COLLISION_MESH;
		[Export]
		ShapeCast3D CEILING_DETECTION;

		[ExportGroup("Controls")]
		[Export]
		string JUMP = "jump";
		[Export]
		string LEFT = "move_left";
		[Export]
		string RIGHT = "move_right";
		[Export]
		string FORWARD = "move_forward";
		[Export]
		string BACKWARD = "move_back";
		[Export]
		string PAUSE = "pause";
		[Export]
		string CROUCH = "crouch";
		[Export]
		string SPRINT = "sprint";

		[ExportGroup("Feature Settings")]
		[Export]
		bool jumpingEnabled = true;
		[Export]
		bool inAirMomentum = true;
		[Export]
		bool motionSmoothing = true;
		[Export]
		bool sprintEnabled = true;
		[Export]
		bool crouchEnabled = true;
		[Export(PropertyHint.Enum, "Hold to Crouch,Toggle Crouch")]
		public int crouchMode = 0;
		[Export(PropertyHint.Enum, "Hold to Sprint,Toggle Sprint")]
		public int sprintMode = 0;
		[Export]
		bool dynamicFOV = true;
		[Export]
		bool continuousJumping = true;
		[Export]
		bool viewBobbing = true;
		[Export]
		bool jumpAnimation = true;

		// Member variables
		float speed;
		float currentSpeed = 0.0f;

		// States: normal, crouching, sprinting
		string state = "normal";
		bool lowCeiling = false; // This is for when the ceiling is too low and the player needs to crouch.
		bool wasOnFloor = true;
		Reticle RETICLE;
		Control USER_INTERFACE => _director.ScreenManager.UserInterface;
		DebugPanel DEBUG_PANEL => _director.ScreenManager.DebugPanel;

		// Get the gravity from the project settings to be synced with RigidBody nodes.
		public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
		// Updates mouse look
		[Export(PropertyHint.Range, "0.0f,1.0f")]
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

			if (defaultReticle != null)
			{
				change_reticle(defaultReticle);
			}

			HEADBOB_ANIMATION.Play("RESET");
			JUMP_ANIMATION.Play("RESET");
			CROUCH_ANIMATION.Play("RESET");
		}

		void change_reticle(string reticlePath)
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

		void HandleGravityAndJumping(double delta)
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

		void HandleMovement(double delta, Vector2 inputDir)
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

		void HandleState(bool moving)
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

		void UpdateCameraFOV()
		{
			CAMERA.Fov = Mathf.Lerp(CAMERA.Fov, state == "sprinting" ? 85 : 75, 0.3f);
		}

		void HeadbobAnimation(bool moving)
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
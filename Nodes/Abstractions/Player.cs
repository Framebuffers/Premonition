using Godot;
using Premonition.Managers;
using Premonition.Nodes.Interfaces;
namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Player : CharacterBody3D, IPlayableCharacter
    {
        private GameDirector Director { get => this.GetGameDirector(); }
        public string PlayerName { get; }
        // How fast the player moves in meters per second.
        [Export]
        public int Speed { get; set; } = 7;

        // The downward acceleration when in the air, in meters per second squared.
        [Export]
        public int FallAcceleration { get; set; } = 75;

        protected Vector3 _targetVelocity = Vector3.Zero;

        public override void _PhysicsProcess(double delta)
        {
            var direction = Vector3.Zero;

            if (Input.IsActionPressed("move_right"))
            {
                direction.X += 1.0f;
            }
            if (Input.IsActionPressed("move_left"))
            {
                direction.X -= 1.0f;
            }
            if (Input.IsActionPressed("move_back"))
            {
                direction.Z += 1.0f;
            }
            if (Input.IsActionPressed("move_forward"))
            {
                direction.Z -= 1.0f;
            }

            if (direction != Vector3.Zero)
            {
                direction = direction.Normalized();
                GetNode<Node3D>("Pivot").Basis = Basis.LookingAt(direction);
            }

            // Ground velocity
            _targetVelocity.X = direction.X * Speed;
            _targetVelocity.Z = direction.Z * Speed;

            // Vertical velocity
            if (!IsOnFloor()) // If in the air, fall towards the floor. Literally gravity
            {
                _targetVelocity.Y -= FallAcceleration * (float)delta;
            }

            // Moving the character
            Velocity = _targetVelocity;
            MoveAndSlide();
        }
    }
}
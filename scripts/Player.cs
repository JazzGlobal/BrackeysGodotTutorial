using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float JumpVelocity = -300.0f;
	
	public AnimatedSprite2D animatedSprite2D;

	// Represents the interactable object that the player is currently colliding with.
	public IInteractable Interactable { get; set; } 

	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		var direction = Input.GetAxis("move_left", "move_right");
		if (direction > 0)
			animatedSprite2D.FlipH = false;
		else if (direction < 0)
			animatedSprite2D.FlipH = true;
		
		// Play Animations
		if (IsOnFloor())
		{
			if (direction == 0)
				animatedSprite2D.Play("idle");
			else
				animatedSprite2D.Play("run");
		}
		else
			animatedSprite2D.Play("jump");
		
		// Handle Interact.
		if (Input.IsActionJustPressed("interact"))
			Interactable?.OnInteract();

		velocity.X = direction * Speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}

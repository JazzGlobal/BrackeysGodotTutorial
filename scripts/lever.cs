using Godot;
using System;

public partial class lever : Area2D, IInteractable
{
	AnimatedSprite2D animatedSprite2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		Connect("body_exited", new Callable(this, nameof(OnBodyExited)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void OnInteract()
	{
		animatedSprite2D.FlipH = !animatedSprite2D.FlipH;	
	}

	private void OnBodyEntered(Node body)
	{
		if (body is Player player)
			player.Interactable = this;
	}

	private void OnBodyExited(Node body)
	{
		if (body is Player player && player.Interactable == this)
			player.Interactable = null;
	}
}

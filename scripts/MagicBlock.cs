using Godot;

public partial class MagicBlock : Node2D, IInteractable
{
	[Export]
	public bool StartVisible = false;
	AnimatedSprite2D animatedSprite2D;
	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite2D.Visible = StartVisible;
	}

	public void OnInteract()
	{
		GD.Print("MagicBlock interacted");
		animatedSprite2D.Visible = !animatedSprite2D.Visible;
	}
}

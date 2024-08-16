using Godot;

public partial class Trigger : Area2D, IInteractable
{
	[Export]
	public Godot.Collections.Array<Node> Interactables;
	public AnimatedSprite2D animatedSprite2D;

	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		Connect("body_exited", new Callable(this, nameof(OnBodyExited)));
	}

	public void OnInteract()
	{
		animatedSprite2D.FlipH = !animatedSprite2D.FlipH;
		foreach (var interactable in Interactables)
		{	
			if (interactable is IInteractable interactable1)
				interactable1.OnInteract();
		}
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

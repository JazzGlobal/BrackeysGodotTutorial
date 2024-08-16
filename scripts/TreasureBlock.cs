using Godot;
using System;

public partial class TreasureBlock : StaticBody2D, IInteractable
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	PackedScene treasure;
	AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D activateCollision;
	bool active = true;
	[Export]
	bool isTrigger = false;

	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		var activateArea = GetNode<Area2D>("ActivateArea");
		activateCollision = activateArea.GetNode<CollisionShape2D>("ActivateCollision");
		GD.Print(activateCollision);
		animatedSprite2D.Play("used");
		activateArea.Connect("body_entered", new Callable(this, nameof(OnActivateAreaBodyEntered)));
	}

	public void OnInteract()
	{
		GrantTreasure();
	}

	void OnActivateAreaBodyEntered(Node body)
	{
		if (!isTrigger)
			GrantTreasure();
	}

	void GrantTreasure()
	{
		if (active)
		{
			animatedSprite2D.Play("unsused");
			var inst = treasure.Instantiate() as Node2D;
			inst.Transform = Transform;
			if (inst.Name == "coin")
				inst.Position -= new Vector2(0, 20);
			else if (inst.Name == "slime")
				inst.Position -= new Vector2(0, 10);
			GetParent().AddChild(inst);
			active = false;
		}
	}
}

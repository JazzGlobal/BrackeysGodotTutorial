extends StaticBody2D

var active = true

@export var treasure: PackedScene
@onready var activate_collision = $ActivateCollision
@onready var animated_sprite = $AnimatedSprite2D

func _ready():
	animated_sprite.play("used")

func _on_activate_area_body_entered(body):
	if active:
		animated_sprite.play("unused")
		var inst = treasure.instantiate()
		inst.transform = transform
		print(inst.name)
		if (inst.name == "coin"):
			inst.position = inst.position - Vector2(0, 20)
		elif(inst.name == "slime"):
			inst.position = inst.position - Vector2(0, 10)
		owner.add_child(inst)
		active = false

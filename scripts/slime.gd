extends Node2D

const SPEED = 60

var direction = 1
@onready var raycast_right = $RaycastRight
@onready var raycast_left = $RaycastLeft
@onready var raycast_down = $RaycastDown
@onready var animated_sprite_2d = $AnimatedSprite2D

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	# If the left or right raycasts are colliding (hit a wall), we need to flip the sprite and change direction.
	# If the down raycast is not colliding (falling off the ground / cliff), then we flip the sprite and change direction.
	if raycast_right.is_colliding() or raycast_left.is_colliding() or !raycast_down.is_colliding():
		direction *= -1
		animated_sprite_2d.flip_h = !animated_sprite_2d.flip_h

	position.x += SPEED * delta * direction	

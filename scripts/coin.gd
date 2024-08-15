extends Area2D
	# Get the area collision / collider 
	# Define on collision event.
	# If collision event is with the player
	# Collect the coin (destory coin and add points to score)

func _on_body_entered(body):
	print("+1 coin")
	queue_free()
	pass # Replace with function body.

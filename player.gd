extends CharacterBody3D

const GRID_STEP = 1.0

func _unhandled_input(event):
	if event.is_action_pressed("ui_right"):
		position.x += GRID_STEP
	elif event.is_action_pressed("ui_left"):
		position.x -= GRID_STEP
	elif event.is_action_pressed("ui_down"):
		position.z += GRID_STEP
	elif event.is_action_pressed("ui_up"):
		position.z -= GRID_STEP

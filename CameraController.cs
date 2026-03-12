using Godot;
using System;

public partial class CameraController : Node3D
{
	[Export] public float ZoomSpeed = 2.0f;
	[Export] public float MinZoom = 5.0f;
	[Export] public float MaxZoom = 50.0f;
	[Export] public float RotationSpeed = 0.5f;

	private Camera3D _camera;
	private bool _isDragging = false;

	public override void _Ready()
	{
		_camera = GetNode<Camera3D>("Camera3D");
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			// zoom
			if (mouseButton.ButtonIndex == MouseButton.WheelUp && mouseButton.Pressed)
			{
				_camera.Size = Mathf.Clamp(_camera.Size - ZoomSpeed, MinZoom, MaxZoom);
			}
			else if (mouseButton.ButtonIndex == MouseButton.WheelDown && mouseButton.Pressed)
			{
				_camera.Size = Mathf.Clamp(_camera.Size + ZoomSpeed, MinZoom, MaxZoom);
			}

			if (mouseButton.ButtonIndex == MouseButton.Middle)
			{
				_isDragging = mouseButton.Pressed;
			}
		}

		// rotate
		if (@event is InputEventMouseMotion mouseMotion && _isDragging)
		{
			// orbit around Y
			Vector3 newRotation = RotationDegrees;
			newRotation.Y -= mouseMotion.Relative.X * RotationSpeed;
			RotationDegrees = newRotation;
		}
	}
}

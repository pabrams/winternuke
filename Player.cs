using Godot;
using System;
using Godot;
using System;

public partial class Player : CharacterBody3D
{
	private const float GridStep = 1.0f;

	public override void _UnhandledInput(InputEvent @event)
	{
		Camera3D cam = GetViewport().GetCamera3D();
		if (cam == null) return;

		// 2. Get camera directions and flatten them on the Y axis
		Vector3 forward = -cam.GlobalTransform.Basis.Z;
		Vector3 right = cam.GlobalTransform.Basis.X;
		forward.Y = 0;
		right.Y = 0;
		forward = forward.Normalized();
		right = right.Normalized();

		if (@event.IsActionPressed("ui_up"))
			MoveOnGrid(forward);
		else if (@event.IsActionPressed("ui_down"))
			MoveOnGrid(-forward);
		else if (@event.IsActionPressed("ui_right"))
			MoveOnGrid(right);
		else if (@event.IsActionPressed("ui_left"))
			MoveOnGrid(-right);
	}

	private void MoveOnGrid(Vector3 direction)
	{
		Vector3 targetDir = Vector3.Zero;

		// 4. Snap to the strongest axis
		if (Mathf.Abs(direction.X) > Mathf.Abs(direction.Z))
		{
			targetDir.X = Mathf.Sign(direction.X);
		}
		else
		{
			targetDir.Z = Mathf.Sign(direction.Z);
		}

		Position += targetDir * GridStep;
	}
}

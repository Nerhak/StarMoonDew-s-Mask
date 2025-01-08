using Godot;
using System;

public partial class PlayButton : Button
{
	public override void _EnterTree() => Pressed += OnButtonPressed;
	public override void _ExitTree() => Pressed -= OnButtonPressed;

	private void OnButtonPressed() => SceneManager.I.ChangeSceneToWorld();
}

using Godot;
using System;

public partial class SceneManager : Node
{
	// Singleton
	public static SceneManager I { get; private set; }

	public override void _Ready()
	{
		if (I != null && I != this)
		{
			QueueFree(); // or throw an error
			return;
		}

		I = this;
	}

	// Scenes
	private static string world { get => "res://Scenes/World/World.tscn"; }

	private void ChangeSceneToFile(string path)
	{
		GetTree().ChangeSceneToFile(path);
	}

	public void ChangeSceneToWorld() => ChangeSceneToFile(world);
}

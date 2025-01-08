using Godot;
using System;

public partial class Global : Node
{
	// Singleton
	public static Global I { get; private set; }

	public override void _Ready()
	{
		if (I != null && I != this)
		{
			QueueFree(); // or throw an error
			return;
		}

		I = this;
	}
}

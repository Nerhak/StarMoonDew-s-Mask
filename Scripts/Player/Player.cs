using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Nodes
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;

	// Paths
	//	Nodes
	private string animatedSprite2DStr = "AnimatedSprite2D";
	private string collisionShape2DStr = "CollisionShape2D";
	//	Animation Paths
	private string animationIdleDownStr = "Idle Down";
	private string animationIdleUpStr = "Idle Up";
	private string animationIdleLeftStr = "Idle Left";
	private string animationIdleRightStr = "Idle Right";
	private string animationWalkDownStr = "Walk Down";
	private string animationWalkUpStr = "Walk Up";
	private string animationWalkLeftStr = "Walk Left";
	private string animationWalkRightStr = "Walk Right";

	// Properties
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>(animatedSprite2DStr);
		collisionShape2D = GetNode<CollisionShape2D>(collisionShape2DStr);

		// animatedSprite2D.Play(animationIdleDownStr);
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

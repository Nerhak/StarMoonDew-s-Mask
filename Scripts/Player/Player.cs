using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Nodes
	// AnimatedSprites2D
	private AnimatedSprite2D Hair;
	private AnimatedSprite2D Body;
	private AnimatedSprite2D Shirt;
	private AnimatedSprite2D Arms;
	private AnimatedSprite2D Pants;

	private CollisionShape2D collisionShape2D;

	// Paths
	//	Nodes
	private string hairPath = "Appearance/Hair";
	private string bodyPath = "Appearance/Body";
	private string shirtPath = "Appearance/Shirt";
	private string armsPath = "Appearance/Arms";
	private string pantsPath = "Appearance/Pants";

	private string collisionShape2DStr = "CollisionShape2D";

	//	Animation Paths
	private string animationIdleDown = "Idle - Down";
	private string animationIdleUp = "Idle - Up";
	private string animationIdleLeft = "Idle - Left";
	private string animationIdleRight = "Idle - Right";
	private string animationWalkDown = "Walk - Down";
	private string animationWalkUp = "Walk - Up";
	private string animationWalkLeft = "Walk - Left";
	private string animationWalkRight = "Walk - Right";

	// Properties
	public const float Speed = 100.0f;
	// public const float JumpVelocity = -400.0f;

	public override void _Ready()
	{
		Hair = GetNode<AnimatedSprite2D>(hairPath);
		Body = GetNode<AnimatedSprite2D>(bodyPath);
		Shirt = GetNode<AnimatedSprite2D>(shirtPath);
		Arms = GetNode<AnimatedSprite2D>(armsPath);
		Pants = GetNode<AnimatedSprite2D>(pantsPath);

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
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;

		Body.Offset = new Vector2(0, 0);
		Hair.Offset = new Vector2(0, 0);
		Shirt.Offset = new Vector2(0, 0);
		Arms.Offset = new Vector2(0, 0);
		Pants.Offset = new Vector2(0, 0);

		if (velocity != Vector2.Zero)
		{
			if (Mathf.Abs(velocity.X) > Mathf.Abs(velocity.Y))
			{
				Shirt.Offset = new Vector2(0, 1);

				if (velocity.X > 0)
				{
					Body.FlipH = false;
					Hair.FlipH = false;
					Shirt.FlipH = false;
					Arms.FlipH = false;
					Pants.FlipH = false;

					Body.Play(animationWalkRight);
					Hair.Play(animationWalkRight);
					Shirt.Play(animationWalkRight);
					Arms.Play(animationWalkRight);
					Pants.Play(animationWalkRight);
				}
				else
				{
					Body.FlipH = true;
					Hair.FlipH = true;
					Shirt.FlipH = true;
					Arms.FlipH = true;
					Pants.FlipH = true;

					Body.Play(animationWalkRight);
					Hair.Play(animationWalkRight);
					Shirt.Play(animationWalkRight);
					Arms.Play(animationWalkRight);
					Pants.Play(animationWalkRight);
				}
			}
			else
			{
				if (velocity.Y > 0)
				{
					Body.Play(animationWalkDown);

					Hair.Offset = new Vector2(0, 1);
					Hair.Play(animationWalkDown);
					
					Shirt.Offset = new Vector2(0, 1);
					Shirt.Play(animationWalkDown);
					Arms.Play(animationWalkDown);
					Pants.Play(animationWalkDown);
				}
				else
				{
					Body.Play(animationWalkUp);
					Hair.Play(animationWalkUp);
					Shirt.Play(animationWalkUp);
					Arms.Play(animationWalkUp);
					Pants.Play(animationWalkUp);
				}
			}
		}
		else
		{
			if (Body.Animation != animationIdleDown)
			{
				Body.Play(animationIdleDown);
				Hair.Play(animationIdleDown);
				Shirt.Play(animationIdleDown);
				Arms.Play(animationIdleDown);
				Pants.Play(animationIdleDown);
			}
		}

		MoveAndSlide();
	}
}

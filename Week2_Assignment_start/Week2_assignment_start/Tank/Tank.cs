using GXPEngine;

// TODO: Fix this mess! - see Assignment 2.2
class Tank : Sprite 
{
	// public fields & properties:
	public Vec2 position 
	{
		get 
		{
			return _position;
		}
	}
	public Vec2 velocity;

	// private fields:
	Vec2 _position;
	Barrel _barrel;

	public Tank(float px, float py) : base("assets/bodies/t34.png") 
	{
		_position.x = px;
		_position.y = py;
		SetOrigin(width / 2, height / 2);
		_barrel = new Barrel ();
		AddChild (_barrel);
	}

	void Controls() 
	{
		velocity *= 0.99f;
		if (Input.GetKey (Key.LEFT)) 
		{
			velocity.RotateDegrees(-1);
		}
		if (Input.GetKey (Key.RIGHT)) 
		{
			velocity.RotateDegrees(1);
		}
		if (Input.GetKey (Key.UP)) 
		{
			velocity += velocity.MoveForward(0.1f);
		}
		if (Input.GetKey (Key.DOWN)) 
		{
			velocity *= 0.1f;
		}
		rotation = velocity.GetAngleDegrees();
	}

	void Shoot() {
		if (Input.GetKeyDown (Key.SPACE)) 
		{
			AddChild (new Bullet (new Vec2 (0, 0), new Vec2 (1, 0)));
		}
	}

	void UpdateScreenPosition() 
	{
		x = _position.x;
		y = _position.y;
	}

	public void Update() 
	{
		Controls ();
		// Basic Euler integration:
		_position += velocity;
		Shoot ();
		UpdateScreenPosition ();
	}
}

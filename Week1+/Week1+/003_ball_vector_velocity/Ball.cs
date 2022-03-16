using System;
using GXPEngine;

public class Ball : EasyDraw
{
	public Vec2 position {
		get {
			return _position;
		}
	}
	public Vec2 velocity;

	int _radius;
	Vec2 _position;
	float _speed;
	bool running = true;

	public Ball (int pRadius, Vec2 pPosition, float pSpeed=5) : base (pRadius*2 + 1, pRadius*2 + 1)
	{
		_radius = pRadius;
		_position = pPosition;
		_speed = pSpeed;

		UpdateScreenPosition ();
		SetOrigin (_radius, _radius);

		Draw (150, 0, 255);
	}

	void Draw(byte red, byte green, byte blue) {
		Fill (red, green, blue);
		Stroke (red, green, blue);
		Ellipse (_radius, _radius, 2*_radius, 2*_radius);
	}

	void KeyControls() {
		velocity.x += Input.mouseX - x;
		velocity.y += Input.mouseY - y;

		//if (Input.GetKey (Key.RIGHT)) {
		//	velocity.x += 1;
		//} else if (Input.GetKey (Key.LEFT)) {
		//	velocity.x -= 1;
		//} 
		//
		//if (Input.GetKey (Key.UP)) {
		//	velocity.y -= 1;
		//} else if (Input.GetKey (Key.DOWN)) {
		//	velocity.y += 1;
		//}

	}

	void UpdateScreenPosition() {
		x = _position.x;
		y = _position.y;
	}

	public void Step () {
		if (!running)
			return;
		Vec2 old = velocity;
		KeyControls ();
		if (velocity.Length() <= _radius)
			running = false;
		velocity.Normalize();
		_position += (((velocity *_speed)*0.2f)+(old*_speed *0.8f));
		_speed += .1f;

		UpdateScreenPosition ();
	}
}

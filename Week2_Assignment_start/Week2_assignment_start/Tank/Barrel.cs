using GXPEngine;
using System;

class Barrel : Sprite 
{
	public Barrel() : base("assets/barrels/t34.png") 
	{
		SetOrigin(width / 2, height / 2);
	}

	public void Update() 
	{
		Vec2 mouse = new Vec2(Input.mouseX, Input.mouseY);
		Vec2 pos = new Vec2(x, y);
		Vec2 rot = pos - mouse;
		rotation = rot.GetAngleDegrees();
	}
}

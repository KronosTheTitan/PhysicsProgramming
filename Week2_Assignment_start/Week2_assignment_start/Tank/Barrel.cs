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
		rotation = Mathf.Atan2(Input.mouseY - y, Input.mouseX - x) * 180 / (Mathf.PI);
	}
}

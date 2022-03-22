using GXPEngine;

class Barrel : Sprite 
{
	public Barrel() : base("assets/barrels/t34.png") 
	{
	}

	public void Update() 
	{
		rotation++;
	}
}

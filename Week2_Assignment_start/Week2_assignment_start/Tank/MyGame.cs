using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	

	static void Main() 
	{
		new MyGame().Start();
	}

	public MyGame () : base(800, 600, false,false)
	{
		// background:
		AddChild (new Sprite ("assets/desert.png"));
		// tank:
		AddChild (new Tank (width / 2, height / 2));// Add your unit tests here:

		Vec2 v = new Vec2(3, 4);
		// Week 1:

		// test v.Length
		Console.WriteLine("Length : "+(v.Length()==5));
		// test v.Normalize
		v.SetXY(6, 8);
		v.Normalize();
		//Console.WriteLine("Normalize : "+());
		// test v.Normalized

		// Week 2 static:

		// test Vec2.Deg2Rad
		Console.WriteLine("Deg2Rad : "+(Vec2.Deg2Rad(90)==.5f));
		// test Vec2.Rad2Deg
		Console.WriteLine("Rad2Deg : " + (Vec2.Rad2Deg(1.5f) == 270f));
		// test Vec2.GetUnitVectorDegrees
		Console.WriteLine("GetUnitVectorDegrees : " + (Vec2.Rad2Deg(1.5f) == 270f));
		// test Vec2.GetUnitVectorRadians
		Console.WriteLine("GetUnitVectorRadians : " + (Vec2.Rad2Deg(1.5f) == 270f));

		// Week 2 instance:

		// test v.GetAngleDegrees
		// test v.GetAngleRadians
		// test v.SetAngleDegrees
		// test v.SetAngleRadians

		// test v.RotateDegrees
		// test v.RotateRadians
		// test v.RotateAroundDegrees
		// test v.RotateAroundRadians

		// Week 4:

		// test v.Normal
		// test v.Dot
		// test v.Reflect
	}
}
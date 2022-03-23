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
		Console.WriteLine("Deg2Rad : "+(Approximate( Vec2.Deg2Rad(90),.5f*Mathf.PI)));
		// test Vec2.Rad2Deg
		Console.WriteLine("Rad2Deg : " + (Approximate(Vec2.Rad2Deg(1.5f*Mathf.PI), 270f)));
		// test Vec2.GetUnitVectorDegrees
		v = Vec2.GetUnitVectorDeg(180f);
		v.Normalize();
		Console.WriteLine("GetUnitVectorDegrees : " + (Approximate(v,new Vec2(-1,0))) + " " + v.ToString());
		// test Vec2.GetUnitVectorRadiansv = Vec2.GetUnitVectorRad(1);
		v = Vec2.GetUnitVectorRad(0.5f*Mathf.PI);
		v.Normalize();
		Console.WriteLine("GetUnitVectorRadians : " + (Approximate(v, new Vec2(0, 1))) + " " + v.ToString());

		// Week 2 instance:

		// test v.GetAngleDegrees
		v = new Vec2(5, 5);
		Console.WriteLine("GetAngleDegrees : " + (Approximate(v.GetAngleDegrees(), 45f)) + " " + v.GetAngleDegrees());
		// test v.GetAngleRadians
		v = new Vec2(0, 5);
		Console.WriteLine("GetAngleRadians : " + (Approximate(v.GetAngleRadians(), 0.5f*Mathf.PI))+ " " + v.GetAngleRadians());
		// test v.SetAngleDegrees
		v = new Vec2(1, 0);
		v.SetAngleDegrees(90f);
		Console.WriteLine("SetAngleDegrees : " + (Approximate(v, new Vec2(0,1))) + " " + v.ToString());
		// test v.SetAngleRadians
		v.SetAngleRadians(1*Mathf.PI);
		Console.WriteLine("SetAngleRadians : " + (Approximate(v, new Vec2(-1, 0))) + " " + v.ToString());

		// test v.RotateDegrees
		v = new Vec2(10, 0);
		v.RotateDegrees(90);
		Console.WriteLine("RotateDegrees : " + Approximate(v,new Vec2(0,10)) + " " + v.ToString());
		// test v.RotateRadians
		v = new Vec2(10, 0);
		v.RotateRadians(1f*Mathf.PI);
		Console.WriteLine("RotateRadians : "+Approximate(v, new Vec2(-10,0)) + " " + v.ToString());
		// test v.RotateAroundDegrees
		v.SetXY(1, 0);
		v.RotateAroundDegrees(new Vec2(1, 1), 90f);
		Console.WriteLine("RotateAroundDegrees : " + Approximate(v, new Vec2(2, 1)) + " " + v.ToString());
		// test v.
		v.SetXY(1, 0);
		v.RotateAroundRadians(new Vec2(1, 1), 0.5f*Mathf.PI);
		Console.WriteLine("RotateAroundRadians : "+Approximate(v,new Vec2(2,1)) + " " + v.ToString());

		// Week 4:

		// test v.Normal
		// test v.Dot
		// test v.Reflect
	}
	/// <summary>
	 /// A helper method for unit testing:
	 /// Returns true if and only if both coordinates of the Vec2s a and b are 
	 /// within the given errorMargin of each other.
	 /// </summary>
	public static bool Approximate(Vec2 a, Vec2 b, float errorMargin = 0.01f)
	{
		return Approximate(a.x, b.x, errorMargin) && Approximate(a.y, b.y, errorMargin);
	}

	/// <summary>
	/// A helper method for unit testing:
	/// Returns true if and only if [a] and [b] differ by at most [errorMargin].
	/// </summary>
	public static bool Approximate(float a, float b, float errorMargin = 0.01f)
	{
		return Math.Abs(a - b) < errorMargin;
	}
}
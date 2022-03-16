using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	

	static void Main() {
		new MyGame().Start();
	}

	Ball _ball;

	EasyDraw _text;

	public MyGame () : base(800, 600, false,false)
	{
		_ball = new Ball (30, new Vec2 (width / 2, height / 2));
		AddChild (_ball);

		_text = new EasyDraw (200,25);
		_text.TextAlign (CenterMode.Min, CenterMode.Min);
		AddChild (_text);
		Vec2 myVec = new Vec2(2, 3);
		Vec2 result = myVec * 3;
		Console.WriteLine("Scalar multiplication right ok ?: " +
		 (result.x == 6 && result.y == 9 && myVec.x == 2 && myVec.y == 3));
		Vec2 result2 = 4 * myVec;
		Console.WriteLine("Scalar multiplication left ok ?: " +
		 (result2.x == 8 && result2.y == 12 && myVec.x == 2 && myVec.y == 3));
		Vec2 result3 = myVec;
		result3.SetXY(3, 4);
		Console.WriteLine("SetXY ok?: " + (result3.x == 3 && result3.y == 4));
		Console.WriteLine("Length ok?: " + (result3.Length() == 5));
		Vec2 result4 = new Vec2(-3f,4f);
		result4.Normalize();
		Console.WriteLine("Normalize ok?: "+(result4.x == -0.6f && result4.y == 0.8f));
		Vec2 result5 = new Vec2(6, 8).Normalized();
		Console.WriteLine("Normalized ok?: " + (result5.x == 0.6f&& result5.y == 0.8f));
	}

	void Update () {
		_ball.Step ();

		_text.Clear (Color.Transparent);
		_text.Text("Velocity: "+_ball.velocity, 0, 0);
	}
}


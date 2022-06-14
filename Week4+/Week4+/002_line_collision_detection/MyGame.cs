using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	

	static void Main() {
		new MyGame().Start();
	}

	Arrow _green;
	Arrow _red;
	Arrow _projection;
	Arrow _perpendicular;

	uint green = 0xff00ff00;
	uint red = 0xffff0000;
	uint yellow = 0xffffff00;
	uint blue = 0xff0000ff;

	Vec2 start;
	Vec2 zero = new Vec2(0, 0);

	Ball _ball;

	EasyDraw _text;

	NLineSegment[] _lineSegments = { 
		new NLineSegment(new Vec2(50, 50), new Vec2(750, 50), 0xff00ff00, 3),
		new NLineSegment(new Vec2(400, 550), new Vec2(50, 50), 0xff00ff00, 3),
		new NLineSegment(new Vec2(750, 550), new Vec2(400, 550), 0xff00ff00, 3),
		new NLineSegment(new Vec2(750,50), new Vec2(750, 550), 0xff00ff00, 3)
	};

	public MyGame () : base(800, 600, false,false)
	{
		_ball = new Ball (30, new Vec2 (0, height / 2));
		AddChild (_ball);

		_text = new EasyDraw (250,25);
		_text.TextAlign (CenterMode.Min, CenterMode.Min);
		AddChild (_text);

		foreach (NLineSegment nLineSegment in _lineSegments)
			AddChild(nLineSegment);

		_green = new Arrow(start, zero, 1, green, 1);
		AddChild(_green);
		_red = new Arrow(start, zero, 1, red, 1);
		AddChild(_red);

		_projection = new Arrow(start, zero, 1, yellow, 1);
		AddChild(_projection);
		_perpendicular = new Arrow(start, zero, 1, blue, 1);
		AddChild(_perpendicular);
		start = new Vec2(width / 2, height / 2);
	}

	void Update () {
		// For now: this just puts the ball at the mouse position:
		_ball.Step ();

		//TODO: calculate correct distance from ball center to line
		foreach (NLineSegment nLine in _lineSegments)
		{
			Vec2 ltb = _ball.position - nLine.start;
			float ballDistance = ltb.Dot((nLine.end - nLine.start).Normal());   //HINT: it's NOT 10000

			//compare distance with ball radius
			if (ballDistance < _ball.radius)
			{

				//compare distance with ball radius
				if (ballDistance < _ball.radius)
				{
					float a = (_ball.oldPosition - nLine.start).Dot((nLine.end - nLine.start).Normal()) - _ball.radius;
					float b = -_ball.velocity.Dot((nLine.end - nLine.start).Normal());
					float t = a / b;
					//_ball.position = _ball.oldPosition + (_ball.velocity * t);
					Vec2 desiredPos = _ball.oldPosition + (_ball.velocity * t);
					Vec2 lineVector = nLine.end - nLine.start;
					float lineLength = lineVector.Length();
					Vec2 _ballToLine = desiredPos - nLine.start;
					float dotProduct = _ballToLine.Dot(lineVector.Normalized());
					if (dotProduct > 0 && dotProduct < lineLength && !(b <= 0 && a < 0))
					{
						_ball.SetColor(1, 0, 0);
						_ball.position = desiredPos;
						_ball.velocity = _ball.velocity.Reflect((nLine.end - nLine.start).Normal(), 1f);
						//if (notbounce)
						//{
						//	LateDestroy();
						//	_ball.LateDestroy();
						//}
						_ball.rotation = _ball.velocity.GetAngleDegrees();
						//_ball.position = _ball.oldPosition + (_ball.velocity * (1 - t));

					}
					else
					{
						_ball.position = _ball.oldPosition + _ball.velocity;
						_ball.SetColor(0, 1, 0);
					}
				}
				else
				{
					_ball.SetColor(0, 1, 0);
				}
			}
		}
	}
}


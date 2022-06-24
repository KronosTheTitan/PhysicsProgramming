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
		new NLineSegment(new Vec2(0, 0), new Vec2(800, 0), 0xff00ff00, 3),
		new NLineSegment(new Vec2(400, 600), new Vec2(0, 300), 0xff00ff00, 3),
		new NLineSegment(new Vec2(0, 300), new Vec2(0, 0), 0xff00ff00, 3),
		new NLineSegment(new Vec2(800, 600), new Vec2(400, 600), 0xff00ff00, 3),
		new NLineSegment(new Vec2(800,0), new Vec2(800, 600), 0xff00ff00, 3),

		new NLineSegment(new Vec2(600, 200), new Vec2(200, 200), 0xff00ff00, 3),
		new NLineSegment(new Vec2(200, 300), new Vec2(400, 400), 0xff00ff00, 3),
		new NLineSegment(new Vec2(200, 200), new Vec2(200, 300), 0xff00ff00, 3),
		new NLineSegment(new Vec2(400, 400), new Vec2(600, 400), 0xff00ff00, 3),
		new NLineSegment(new Vec2(600,400), new Vec2(600, 200), 0xff00ff00, 3)
	};

	public MyGame () : base(800, 600, false,false)
	{
		_ball = new Ball (30, new Vec2 (0, height / 2),0f);
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
		
		UnitTests.RunTests();
	}

	void Update () {
		Aim();
		
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
				//
				float a = ( nLine.start - _ball.oldPosition).Dot((nLine.start - nLine.end).Normal()) - _ball.radius;
				float b = -_ball.velocity.Dot((nLine.end - nLine.start).Normal());
				float t = a / b;
				Vec2 desiredPos = _ball.oldPosition + (_ball.velocity * t);
				Vec2 lineVector = nLine.end - nLine.start;
				float lineLength = lineVector.Length();
				Vec2 _ballToLine = desiredPos - nLine.start;
				float dotProduct = _ballToLine.Dot(lineVector.Normalized());
				if ((dotProduct >= 0 && dotProduct <= lineLength) && !(b <= 0) && !(a < 0))
				{
					_ball.position = desiredPos;
					_ball.velocity = _ball.velocity.Reflect((nLine.end - nLine.start).Normal(), .2f);
					
					/*Console.WriteLine("---Collision at "+Time.time+"---");
					Console.WriteLine(t + " : " + a + " : " + b);
					Console.WriteLine(_ball.velocity);
					Console.WriteLine((nLine.end - nLine.start).Normal());
					Console.WriteLine("--------------------------------");*/
					
					_ball.rotation = _ball.velocity.GetAngleDegrees();
					continue;
				}
				else
				{
					_ball.position = _ball.oldPosition + _ball.velocity;
					_ball.SetColor(0, 1, 0);

					if (_ball.radius + 0>=(_ball.position-nLine.start).Length())
					{
						Vec2 normal = new Vec2();

						Vec2 u = _ball.oldPosition - (nLine.start);
						float aC = Mathf.Pow(_ball.velocity.Length(), 2);
						float bC = u.Dot(_ball.velocity) * 2;
						float cC = Mathf.Pow(u.Length(), 2) - Mathf.Pow(_ball.radius + 0, 2);
						float DC = Mathf.Pow(b, 2) - (4 * aC * cC);

						if (cC < 0)
						{
							if (bC < 0)
							{
								_ball.velocity = _ball.velocity.Reflect((nLine.end - nLine.start).Normal(), .2f);
								_ball.rotation = _ball.velocity.GetAngleDegrees();
							}
						}
					}
					if (_ball.radius + 0>=(_ball.position-nLine.end).Length())
					{
						Vec2 normal = new Vec2();

						Vec2 u = _ball.oldPosition - (nLine.end);
						float aC = Mathf.Pow(_ball.velocity.Length(), 2);
						float bC = u.Dot(_ball.velocity) * 2;
						float cC = Mathf.Pow(u.Length(), 2) - Mathf.Pow(_ball.radius + 0, 2);
						float DC = Mathf.Pow(b, 2) - (4 * aC * cC);

						if (cC < 0)
						{
							if (bC < 0)
							{
								_ball.velocity = _ball.velocity.Reflect((nLine.end - nLine.start).Normal(), .2f);
								_ball.rotation = _ball.velocity.GetAngleDegrees();

							}
						}
					}
					
					continue;
				}
			}
			else
			{
				continue;
			}
		}
		SetBallColor();

		
	}
	void Aim()
	{
		if(_ball.velocity.Length() >= 1f) return;
		_ball.rotation = (_ball.position - new Vec2(Input.mouseX, Input.mouseY)).GetAngleDegrees();
		if (Input.GetMouseButtonUp(0))
		{
			_ball.velocity = (new Vec2(Input.mouseX, Input.mouseY) - _ball.position).Normalized() * 5;
		}
			
	}

	void SetBallColor()
	{
		if (_ball.velocity.Length() >= 1f)
		{
			_ball.SetColor(1,1,0);
		}
		else
		{
			_ball.SetColor(0,1,0);
		}
	}
}


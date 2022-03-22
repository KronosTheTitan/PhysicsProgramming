using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2 
{
	public float x;
	public float y;

	public Vec2 (float pX = 0, float pY = 0) 
	{
		x = pX;
		y = pY;
	}
	public void Normalize()
    {
		if (Length() == 0)
			return;
		float length = Length();
		x = x / length;
		y = y / length;
    }
	public Vec2 Normalized()
    {
		Vec2 output = new Vec2(x, y);
		output.Normalize();
		return output;
    }
	public void SetXY(float X,float Y)
    {
		x = X;
		y = Y;
    }

	// TODO: Implement Length, Normalize, Normalized, SetXY methods (see Assignment 1)

	public float Length() {
		// TODO: return the vector length
		return Mathf.Sqrt((x*x)+(y*y));
	}

	// TODO: Implement subtract, scale operators

	public static Vec2 operator+ (Vec2 left, Vec2 right) {
		return new Vec2(left.x+right.x, left.y+right.y);
	}
	public static Vec2 operator -(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}
	public static Vec2 operator *(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x * right.x, left.y * right.y);
	}
	public static Vec2 operator *(Vec2 left, float right)
	{
		return new Vec2(left.x * right, left.y * right);
	}
	public static Vec2 operator *(float left, Vec2 right)
	{
		return new Vec2(left * right.x, left * right.y);
	}
	public static Vec2 operator /(float left, Vec2 right)
	{
		return new Vec2(left / right.x, left / right.y);
	}
	public static Vec2 operator /(Vec2 left, float right)
	{
		return new Vec2(left.x / right, left.y / right);
	}
	public override string ToString () 
	{
		return String.Format ("({0},{1})", x, y);
	}
	public static float Deg2Rad(float f)
    {
		return f*(Math.PI)
    }
	public static float Rad2Deg(float f)
    {

    }
	public static Vec2 GetUnitVectorDeg()
    {

    }
	public static Vec2 GetUnitVectorRad()
    {

    }
	public static void RandomUnitVector()
    {

    }
	public void SetAngleDegrees()
    {

    }
	public void SetAngleRadians()
    {

    }
	public float GetAngleRadians()
    {

    }
	public float GetAngleDegrees()
    {

    }
	public void RotateDegrees()
    {

    }
	public void RotateRadians()
    {

    }
	public void RotateAroundDegrees()
    {

    }
	public void RotateAroundRadians()
    {

    }
}


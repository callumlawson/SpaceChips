using System;
using UnityEngine;

internal class SpaceMath
{
    public static float PositionsToBearing(float fromX, float fromY, float toX, float toY)
    {
        float xDiff = toX - fromX;
        float yDiff = toY - fromY;
        return (float) (Math.Atan2(yDiff, xDiff)*(180.0/Math.PI));
    }

    public static Vector2 BearingToNormalizedVector2(float bearing)
    {
        double angleInRadians = Math.PI*(bearing/180.0);
        return new Vector2((float) Math.Cos(angleInRadians), (float) Math.Sin(angleInRadians)).normalized;
    }

    public static float DistanceBetweenTwoPoints(float fromX, float fromY, float toX, float toY)
    {
        return (float) Math.Sqrt(Math.Pow((double) fromX - toX, 2.0) + Math.Pow((double) fromY - toY, 2.0));
    }
}
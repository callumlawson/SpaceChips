using UnityEngine;

internal class Scanner : Component
{
    private readonly AnalogueWire bearingOutput;
    private readonly AnalogueWire rangeOutput;

    public Scanner(Simulation simulation, Ship ship, World world, AnalogueWire rangeOutput, AnalogueWire bearingOutput)
        : base(simulation, ship, world)
    {
        this.rangeOutput = rangeOutput;
        this.bearingOutput = bearingOutput;
    }

    public override void OnClockEdge()
    {
        Ship nearestShip = World.GetNearestShip(Ship);
        bearingOutput.SignalValue = SpaceMath.PositionsToBearing(Ship.X, Ship.Y, nearestShip.X, nearestShip.Y) - Ship.RotationInDegrees;
        rangeOutput.SignalValue = SpaceMath.DistanceBetweenTwoPoints(Ship.X, Ship.Y, nearestShip.X, nearestShip.Y);
    }
}
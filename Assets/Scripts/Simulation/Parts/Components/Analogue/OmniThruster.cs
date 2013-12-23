using System;
using UnityEngine;

internal class OmniThruster : Component
{
    private readonly AnalogueWire bearingInput;
    private readonly AnalogueWire thrustMagnitudeInput;

    public OmniThruster(Simulation simulation, Ship ship, World world, AnalogueWire bearingInput, AnalogueWire thrustMagnitudeInput) : base(simulation, ship, world)
    {
        this.bearingInput = bearingInput;
        this.thrustMagnitudeInput = thrustMagnitudeInput;
    }

    public override void OnClockEdge()
    {
        var thrustBearing = bearingInput.SignalValue + Ship.RotationInDegrees;
        var thrustVector = SpaceMath.BearingToNormalizedVector2(thrustBearing) * thrustMagnitudeInput.SignalValue;
        Ship.X += thrustVector.x;
        Ship.Y += thrustVector.y;

        Ship.RotationInDegrees = Mathf.Lerp(Ship.RotationInDegrees, thrustBearing, 0.04f);
    }
}
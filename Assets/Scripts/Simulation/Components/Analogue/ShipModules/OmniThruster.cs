using UnityEngine;

internal class OmniThruster : Component
{
    private readonly AnalogueWire bearingInput;
    private readonly AnalogueWire thrustMagnitudeInput;

    public OmniThruster(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, AnalogueWire bearingInput,
        AnalogueWire thrustMagnitudeInput) : base(engineEvents, simulation, ship, world)
    {
        this.bearingInput = bearingInput;
        this.thrustMagnitudeInput = thrustMagnitudeInput;
    }

    public override void OnClockEdge()
    {
        var thrustBearing = bearingInput.SignalValue + Ship.RotationInDegrees;
        var thrustVector = SpaceMath.BearingToNormalizedVector2(thrustBearing)*thrustMagnitudeInput.SignalValue;
        Ship.PositionX += thrustVector.x;
        Ship.PositionY += thrustVector.y;

        Ship.RotationInDegrees = Mathf.Lerp(Ship.RotationInDegrees, thrustBearing, 0.04f);
    }
}
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;
using Component = Assets.Scripts.Simulation.Components.Component;

internal class OmniThruster : Component
{
    private readonly AnalogueWire bearingInput;
    private readonly AnalogueWire thrustMagnitudeInput;
    private readonly Ship ship;

    public OmniThruster(Brain brain, Ship ship, World world, AnalogueWire bearingInput,
        AnalogueWire thrustMagnitudeInput) : base()
    {
        this.ship = ship;
        this.bearingInput = bearingInput;
        this.thrustMagnitudeInput = thrustMagnitudeInput;
    }

    public override void OnClockEdge()
    {
        var thrustBearing = bearingInput.SignalValue + ship.RotationInDegrees;
        var thrustVector = SpaceMath.BearingToNormalizedVector2(thrustBearing)*thrustMagnitudeInput.SignalValue;
        ship.PositionX += thrustVector.x;
        ship.PositionY += thrustVector.y;

        ship.RotationInDegrees = Mathf.Lerp(ship.RotationInDegrees, thrustBearing, 0.04f);
    }
}
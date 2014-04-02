using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;
using UnityEngine;
using Component = Assets.Scripts.Simulation.Components.Component;

internal class OmniThruster : Component
{
    private readonly AnalogueWire bearingInput;
    private readonly AnalogueWire thrustMagnitudeInput;
    private readonly Ship ship;

    public OmniThruster(Ship ship, AnalogueWire bearingInput, AnalogueWire thrustMagnitudeInput)
    {
        this.ship = ship;
        this.bearingInput = bearingInput;
        this.thrustMagnitudeInput = thrustMagnitudeInput;
    }

    public override void OnClockEdge()
    {
        var thrustBearing = bearingInput.SignalValue;
        var thrustVector = SpaceMath.BearingToNormalizedVector2(thrustBearing)*thrustMagnitudeInput.SignalValue;
        ship.PositionX += thrustVector.x;
        ship.PositionY += thrustVector.y;
    }
}
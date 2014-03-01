using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;
using Component = Assets.Scripts.Simulation.Components.Component;

internal class OmniThruster : Component
{
    private readonly AnalogueWire bearingInput;
    private readonly AnalogueWire thrustMagnitudeInput;
    private readonly Ship ship;

    public OmniThruster(Ship ship, AnalogueWire bearingInput, AnalogueWire thrustMagnitudeInput)
    {
        Debug.Log("Omnithruster created");
        this.ship = ship;
        this.bearingInput = bearingInput;
        this.thrustMagnitudeInput = thrustMagnitudeInput;
    }

    public override void OnClockEdge()
    {
        Debug.Log("Omnithruster updated with bearing input: " + bearingInput.SignalValue);

        var thrustBearing = bearingInput.SignalValue;
        var thrustVector = SpaceMath.BearingToNormalizedVector2(thrustBearing)*thrustMagnitudeInput.SignalValue;
        ship.PositionX += thrustVector.x;
        ship.PositionY += thrustVector.y;

       //Shoudnt be here 
//       ship.RotationInDegrees = Mathf.Lerp(ship.RotationInDegrees, thrustBearing, 0.04f);
    }
}
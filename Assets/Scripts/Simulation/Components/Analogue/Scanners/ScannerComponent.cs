using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

abstract class ScannerComponent : Component
{
    private readonly AnalogueWire bearingOutput;
    private readonly AnalogueWire rangeOutput;
    private readonly Ship ship;

    protected ScannerComponent(Ship ship, AnalogueWire bearingOutput, AnalogueWire rangeOutput)
    {
        this.ship = ship;
        this.rangeOutput = rangeOutput;
        this.bearingOutput = bearingOutput;
    }

    public override void OnClockEdge()
    {
        Ship selectedShip = ShipSelector();
        if (selectedShip != null)
        {
            bearingOutput.SignalValue = SpaceMath.PositionsToBearing(ship.PositionX, ship.PositionY, selectedShip.PositionX, selectedShip.PositionY) - ship.RotationInDegrees;
            rangeOutput.SignalValue = SpaceMath.DistanceBetweenTwoPoints(ship.PositionX, ship.PositionY, selectedShip.PositionX, selectedShip.PositionY);
        }
    }

    protected abstract Ship ShipSelector();
}
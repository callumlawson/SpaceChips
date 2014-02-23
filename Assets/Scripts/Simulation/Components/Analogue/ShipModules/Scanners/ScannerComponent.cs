using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

abstract class ScannerComponent : Component
{
    private readonly AnalogueWire bearingOutput;
    private readonly AnalogueWire rangeOutput;
    private readonly Ship ship;

    protected ScannerComponent(Brain brain, Ship ship, World world, AnalogueWire rangeOutput, AnalogueWire bearingOutput)
        : base()
    {
        this.ship = ship;
        this.rangeOutput = rangeOutput;
        this.bearingOutput = bearingOutput;
    }

    public override void OnClockEdge()
    {
        Ship nearestShip = ShipSelector();
        if (nearestShip != null)
        {
            bearingOutput.SignalValue = SpaceMath.PositionsToBearing(ship.PositionX, ship.PositionY, nearestShip.PositionX, nearestShip.PositionY) - ship.RotationInDegrees;
            rangeOutput.SignalValue = SpaceMath.DistanceBetweenTwoPoints(ship.PositionX, ship.PositionY, nearestShip.PositionX, nearestShip.PositionY);
        }
    }

    protected abstract Ship ShipSelector();
}
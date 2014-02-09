abstract class ScannerComponent : Component
{
    private readonly AnalogueWire bearingInput;
    private readonly AnalogueWire rangeInput;
    private readonly Ship ship;

    protected ScannerComponent(EngineEvents engineEvents, Simulation simulation, Ship ship, World world,
        AnalogueWire rangeInput, AnalogueWire bearingInput)
        : base(simulation)
    {
        this.ship = ship;
        this.rangeInput = rangeInput;
        this.bearingInput = bearingInput;
    }

    public override void OnClockEdge()
    {
        Ship nearestShip = ShipSelector();
        if (nearestShip != null)
        {
            bearingInput.SignalValue = SpaceMath.PositionsToBearing(ship.PositionX, ship.PositionY, nearestShip.PositionX, nearestShip.PositionY) - ship.RotationInDegrees;
            rangeInput.SignalValue = SpaceMath.DistanceBetweenTwoPoints(ship.PositionX, ship.PositionY, nearestShip.PositionX, nearestShip.PositionY);
        }
    }

    protected abstract Ship ShipSelector();
}
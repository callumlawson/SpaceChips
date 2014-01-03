abstract class ScannerComponent : Component
{
    private readonly AnalogueWire bearingInput;
    private readonly AnalogueWire rangeInput;

    protected ScannerComponent(EngineEvents engineEvents, Simulation simulation, Ship ship, World world,
        AnalogueWire rangeInput, AnalogueWire bearingInput)
        : base(engineEvents, simulation, ship, world)
    {
        this.rangeInput = rangeInput;
        this.bearingInput = bearingInput;
    }

    public override void OnClockEdge()
    {
        Ship nearestShip = ShipSelector();
        if (nearestShip != null)
        {
            bearingInput.SignalValue = SpaceMath.PositionsToBearing(Ship.PositionX, Ship.PositionY, nearestShip.PositionX, nearestShip.PositionY) - Ship.RotationInDegrees;
            rangeInput.SignalValue = SpaceMath.DistanceBetweenTwoPoints(Ship.PositionX, Ship.PositionY, nearestShip.PositionX, nearestShip.PositionY);
        }
    }

    protected abstract Ship ShipSelector();
}
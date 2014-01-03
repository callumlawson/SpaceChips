internal class BasicScanner : ScannerComponent
{
    public BasicScanner(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, AnalogueWire rangeInput, AnalogueWire bearingInput)
        : base(engineEvents, simulation, ship, world, rangeInput, bearingInput) {}

    protected override Ship ShipSelector()
    {
        return World.GetNearestShip(Ship);
    }
}
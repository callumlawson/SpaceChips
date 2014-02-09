internal class BasicScanner : ScannerComponent
{
    private readonly Ship ship;
    private readonly World world;

    public BasicScanner(Simulation simulation, Ship ship, World world, AnalogueWire rangeOutput, AnalogueWire bearingOutput)
        : base(simulation, ship, world, rangeOutput, bearingOutput)
    {
        this.world = world;
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return world.GetNearestShip(ship);
    }
}
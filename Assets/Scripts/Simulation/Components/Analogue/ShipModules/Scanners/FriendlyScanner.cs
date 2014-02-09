internal class FriendlyScanner : ScannerComponent
{
    private readonly Ship ship;
    private readonly World world;

    public FriendlyScanner(Simulation simulation, Ship ship, World world, AnalogueWire rangeOutput, AnalogueWire bearingOutput)
        : base(simulation, ship, world, rangeOutput, bearingOutput)
    {
        this.world = world;
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return world.GetNearestShipOnTeam(ship, ship.Team);
    }
}
internal class FriendlyScanner : ScannerComponent
{
    private readonly Ship ship;
    private readonly World world;

    public FriendlyScanner(Simulation simulation, Ship ship, World world, AnalogueWire rangeInput, AnalogueWire bearingInput)
        : base(simulation, ship, world, rangeInput, bearingInput)
    {
        this.world = world;
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return world.GetNearestShipOnTeam(ship, ship.Team);
    }
}
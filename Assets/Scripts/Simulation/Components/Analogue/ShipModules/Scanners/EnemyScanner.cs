internal class EnemyScanner : ScannerComponent
{
    private readonly Ship ship;
    private readonly World world;

    public EnemyScanner(Simulation simulation, Ship ship, World world, AnalogueWire rangeInput, AnalogueWire bearingInput)
        : base(simulation, ship, world, rangeInput, bearingInput)
    {
        this.world = world;
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return world.GetNearestShipNotOnTeam(ship, ship.Team);
    }
}
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class FriendlyScanner : ScannerComponent
{
    private readonly Ship ship;
    private readonly World world;

    public FriendlyScanner(Brain brain, Ship ship, World world, AnalogueWire rangeOutput, AnalogueWire bearingOutput)
        : base(brain, ship, world, rangeOutput, bearingOutput)
    {
        this.world = world;
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return world.GetNearestShipOnTeam(ship, ship.Team);
    }
}
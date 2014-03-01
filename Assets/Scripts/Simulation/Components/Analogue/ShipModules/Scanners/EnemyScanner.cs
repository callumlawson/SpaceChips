using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class EnemyScanner : ScannerComponent
{
    private readonly Ship ship;

    public EnemyScanner(Ship ship, AnalogueWire bearingOutput, AnalogueWire rangeOutput)
        : base(ship, rangeOutput, bearingOutput)
    {
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return ship.GetNearestShipNotOnTeam();
    }
}
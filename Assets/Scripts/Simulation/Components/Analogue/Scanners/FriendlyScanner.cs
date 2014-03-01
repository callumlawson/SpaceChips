using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class FriendlyScanner : ScannerComponent
{
    private readonly Ship ship;

    public FriendlyScanner(Ship ship, AnalogueWire bearingOutput, AnalogueWire rangeOutput)
        : base(ship, rangeOutput, bearingOutput)
    {
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return ship.GetNearestShipOnTeam();
    }
}
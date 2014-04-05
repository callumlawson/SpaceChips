using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class BasicScanner : ScannerComponent
{
    private readonly Ship ship;

    public BasicScanner(Ship ship, AnalogueWire bearingOutput, AnalogueWire rangeOutput)
        : base(ship, rangeOutput, bearingOutput)
    {
        this.ship = ship;
    }

    protected override Ship ShipSelector()
    {
        return ship.GetNearestShip();
    }
}
internal interface ShipChip
{
    void Setup(ShipModel ship, World world, Simulation simulation);
}

internal class BasicChip : ShipChip
{
    public void Setup(ShipModel ship, World world, Simulation simulation)
    {
        var rangeWire = new Wire();
        var bearingWire = new Wire();
        var deltaXWire = new Wire();
        var deltaYWire = new Wire();

        new Scanner(simulation, world, rangeWire, bearingWire);
        new Probe(simulation, "Range", rangeWire);
        new Probe(simulation, "Bearing", bearingWire);
        new Constant(simulation, 0.005f, deltaXWire);
        new Constant(simulation, 0.001f, deltaYWire);
        new Engine(simulation, ship, deltaXWire, deltaYWire);
    }
}

internal class PassiveScannerChip : ShipChip
{
    public void Setup(ShipModel ship, World world, Simulation simulation)
    {
        var rangeWire = new Wire();
        var bearingWire = new Wire();

        new Scanner(simulation, world, rangeWire, bearingWire);
        new Probe(simulation, "Range", rangeWire);
        new Probe(simulation, "Bearing", bearingWire);
    }
}
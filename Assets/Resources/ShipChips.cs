internal interface ShipChip
{
    void Setup(Ship ship, World world, Simulation simulation);
}

internal class BasicChip : ShipChip
{
    public void Setup(Ship ship, World world, Simulation simulation)
    {
        var rangeWire = new AnalogueWire();
        var bearingWire = new AnalogueWire();
        var thrustMangnitudeWire = new AnalogueWire();

        new Scanner(simulation, ship, world, rangeWire, bearingWire);
        new AnalogueProbe(simulation, ship, world, "Bearing", bearingWire);
        new AnalogueConstant(simulation, ship, world, 0.01f, thrustMangnitudeWire);
        new OmniThruster(simulation, ship, world, bearingWire, thrustMangnitudeWire);
    }
}

internal class PassiveChip : ShipChip
{
    public void Setup(Ship ship, World world, Simulation simulation) { }
}
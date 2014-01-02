internal interface ShipChip
{
    void Setup(Ship ship, World world, Simulation simulation);
}

internal class BasicChip : ShipChip
{
    public void Setup(Ship ship, World world, Simulation simulation)
    {
        var rangeWire = new AnalogueWire(simulation);
        var bearingWire = new AnalogueWire(simulation);
        var thrustMangnitudeWire = new AnalogueWire(simulation);

        new Scanner(simulation, ship, world, rangeWire, bearingWire);
        new AnalogueProbe(simulation, ship, world, "Bearing", bearingWire);
        new AnalogueConstant(simulation, ship, world, 0.01f, thrustMangnitudeWire);
        new OmniThruster(simulation, ship, world, bearingWire, thrustMangnitudeWire);
    }
}

internal class OrbitChip : ShipChip
{
	public void Setup(Ship ship, World world, Simulation simulation){

		var distWire = new AnalogueWire(simulation);
		var errorWire = new AnalogueWire(simulation);
		var distThrustWire = new AnalogueWire(simulation);
		var constDistWire = new AnalogueWire(simulation);
		var distScalingWire = new AnalogueWire(simulation);
		var orbitThrustWire = new AnalogueWire(simulation);
		var netThrustWire = new AnalogueWire(simulation);

		var bearingWire = new AnalogueWire(simulation);
		var orbitBearing = new AnalogueWire(simulation);
		var netBearingWire = new AnalogueWire(simulation);

		new Scanner(simulation, ship, world, distWire, bearingWire);

		//Thrust calculations
		new AnalogueConstant(simulation, ship, world, 0.5f, constDistWire);
		new AMinusB(simulation, ship, world, distWire, constDistWire, errorWire);
		new AnalogueConstant(simulation, ship, world, 0.01f, distScalingWire); 
		new ATimesB(simulation, ship, world, errorWire, distScalingWire, distThrustWire);
		new AnalogueConstant(simulation, ship, world, 0.01f, orbitThrustWire);
		new AAddB(simulation, ship, world, distThrustWire, orbitThrustWire, netThrustWire);

		//Bearing calculations
		new AnalogueConstant(simulation, ship, world, 90.0f, orbitBearing);
		new AAddB(simulation, ship, world, orbitBearing, bearingWire, netBearingWire);

		new OmniThruster(simulation, ship, world, netBearingWire, netThrustWire);

	}
}

internal class PassiveChip : ShipChip
{
    public void Setup(Ship ship, World world, Simulation simulation) { }
}
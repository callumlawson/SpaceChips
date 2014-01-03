internal interface ShipChip
{
    void Setup(EngineEvents engineEvents, Ship ship, World world, Simulation simulation);
}

internal class BasicChip : ShipChip
{
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Simulation simulation)
    {
        var rangeWire = new AnalogueWire(simulation);
        var bearingWire = new AnalogueWire(simulation);
        var thrustMangnitudeWire = new AnalogueWire(simulation);

        new Scanner(engineEvents, simulation, ship, world, rangeWire, bearingWire);
        new AnalogueProbe(engineEvents, simulation, ship, world, "Bearing", bearingWire);
        new AnalogueConstant(engineEvents, simulation, ship, world, 0.01f, thrustMangnitudeWire);
        new OmniThruster(engineEvents, simulation, ship, world, bearingWire, thrustMangnitudeWire);
        new BasicTurret(engineEvents, simulation, ship, world, bearingWire);
    }
}

internal class CowardChip : ShipChip
{
	public void Setup(Ship ship, World world, Simulation simulation)
	{
		var rangeWire = new AnalogueWire(simulation);
		var bearingWire = new AnalogueWire(simulation);
		var thrustMangnitudeWire = new AnalogueWire(simulation);
		var finalThrustWire = new AnalogueWire(simulation);
		var logicOutputWire = new DigitalWire(simulation);
		var stallDistWire = new AnalogueWire(simulation);
		var negativeBearingWire = new AnalogueWire(simulation);
		var finalBearingWire = new AnalogueWire(simulation);

		new AnalogueConstant(simulation, ship, world, 5.0f, stallDistWire);
		new AnalogueConstant(simulation, ship, world, 0.02f, thrustMangnitudeWire);
		new AnalogueConstant(simulation, ship, world, 180.0f, negativeBearingWire);
		new AMinusB(simulation, ship, world, bearingWire, negativeBearingWire, finalBearingWire);
		new ASuppressB(simulation, ship, world, logicOutputWire, thrustMangnitudeWire, finalThrustWire);
		new AGreaterThanB(simulation, ship, world, rangeWire, stallDistWire, logicOutputWire);
		new Scanner(simulation, ship, world, rangeWire, bearingWire);
		new OmniThruster(simulation, ship, world, finalBearingWire, finalThrustWire);
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
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Simulation simulation) { }
}
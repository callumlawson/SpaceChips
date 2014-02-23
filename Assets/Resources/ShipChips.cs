using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;
using Assets.Scripts.Visualisation;

//TODO - Wrap Ship events etc into context when code layout settles.
using Assets.Scripts.Visualisation.Controllers;

public interface ShipChip
{
    void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain);
}

internal class BasicChip : ShipChip
{
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain)
    {
        var rangeWire = new AnalogueWire();
        var bearingWire = new AnalogueWire();
        var thrustMangnitudeWire = new AnalogueWire();

        var scanner = new BasicScanner(brain, ship, world, rangeWire, bearingWire);
        var turret = new BasicTurret(ship, world, bearingWire);
        new AnalogueProbe(brain, ship, world, "Bearing", bearingWire);
        new AnalogueConstant(brain, ship, world, 0.01f, thrustMangnitudeWire);
        new OmniThruster(brain, ship, world, bearingWire, thrustMangnitudeWire);
       
        new TurretVisualiserController(engineEvents, ship, turret, ComponentPaths.BasicTurretComponent);
        new ScannerVisualiserController(engineEvents, ship, scanner, ComponentPaths.BasicScannerComponent);
    }
}

internal class CowardChip : ShipChip
{
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain)
	{
		var rangeWire = new AnalogueWire();
		var bearingWire = new AnalogueWire();
		var thrustMangnitudeWire = new AnalogueWire();
		var finalThrustWire = new AnalogueWire();
		var logicOutputWire = new DigitalWire();
		var stallDistWire = new AnalogueWire();
		var negativeBearingWire = new AnalogueWire();
		var finalBearingWire = new AnalogueWire();

        new AnalogueConstant(brain, ship, world, 5.0f, stallDistWire);
        new AnalogueConstant(brain, ship, world, 0.02f, thrustMangnitudeWire);
        new AnalogueConstant(brain, ship, world, 180.0f, negativeBearingWire);
        new AMinusB(brain, ship, world, bearingWire, negativeBearingWire, finalBearingWire);
		new ASuppressB(brain, ship, world, logicOutputWire, thrustMangnitudeWire, finalThrustWire);
        new AGreaterThanB(brain, ship, world, rangeWire, stallDistWire, logicOutputWire);
        new BasicScanner(brain, ship, world, rangeWire, bearingWire);
        new OmniThruster(brain, ship, world, finalBearingWire, finalThrustWire);
	}
}

internal class OrbitChip : ShipChip
{
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain)
    {

		var distWire = new AnalogueWire();
		var errorWire = new AnalogueWire();
		var distThrustWire = new AnalogueWire();
		var constDistWire = new AnalogueWire();
		var distScalingWire = new AnalogueWire();
		var orbitThrustWire = new AnalogueWire();
		var netThrustWire = new AnalogueWire();

		var bearingWire = new AnalogueWire();
		var orbitBearing = new AnalogueWire();
		var netBearingWire = new AnalogueWire();

        new BasicScanner(brain, ship, world, distWire, bearingWire);

		//Thrust calculations
        new AnalogueConstant(brain, ship, world, 0.5f, constDistWire);
        new AMinusB(brain, ship, world, distWire, constDistWire, errorWire);
        new AnalogueConstant(brain, ship, world, 0.01f, distScalingWire);
        new ATimesB(brain, ship, world, errorWire, distScalingWire, distThrustWire);
        new AnalogueConstant(brain, ship, world, 0.01f, orbitThrustWire);
        new AAddB(brain, ship, world, distThrustWire, orbitThrustWire, netThrustWire);

		//Bearing calculations
        new AnalogueConstant(brain, ship, world, 90.0f, orbitBearing);
        new AAddB(brain, ship, world, orbitBearing, bearingWire, netBearingWire);

        new OmniThruster(brain, ship, world, netBearingWire, netThrustWire);
	}
}

internal class PassiveChip : ShipChip
{
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain) { }
}
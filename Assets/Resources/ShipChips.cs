//TODO - Wrap Ship events etc into context when code layout settles.

using System.Collections.Generic;
using Assets.Scripts.ShipBuilding.Definitions;
using Assets.Scripts.ShipLoader.ShipLoading;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;

public interface ShipChip
{
    void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain);
}

internal static class ShipDefs
{
    public static ShipDefinition BasicShip()
    {
        const ShipViewType shipViewType = ShipViewType.BasicShip;
                                                 //rangeWire                               //bearing wire                            //thrust magnitudeWire
        var wireDefs = new List<WireDefinition> {new WireDefinition(WireType.Analogue, 0), new WireDefinition(WireType.Analogue, 1), new WireDefinition(WireType.Analogue, 2)};
        var hardpointDefs = new List<HardpointDefinition> {new HardpointDefinition(HardpointType.LazerTurret, ComponentViewType.Turret, 0, Vector2.zero)};
        var componentDefs = new List<ComponentDefinition>
        {
            new ComponentDefinition(ComponentType.BasicTurret, 0, new List<int> {1}),
            new ComponentDefinition(ComponentType.BasicScanner, null, new List<int> {0, 1}),
            new ComponentDefinition(ComponentType.OmniThruster, null, new List<int> {1, 2}),
            new ComponentDefinition(ComponentType.AnalogueConstant, null, new List<int> {2})
        };

        return new ShipDefinition(shipViewType, hardpointDefs, componentDefs, wireDefs);
    }
}

internal class BasicChip : ShipChip
{
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain)
    {
        var rangeWire = new AnalogueWire();
        var bearingWire = new AnalogueWire();
        var thrustMagnitudeWire = new AnalogueWire();

        var scanner = new BasicScanner(ship, rangeWire, bearingWire);
        var turret = new BasicTurret(ship, bearingWire);
        new AnalogueProbe(brain, ship, world, "Bearing", bearingWire);
        new AnalogueConstant(ship, 0.01f, thrustMagnitudeWire);
        new OmniThruster(ship, bearingWire, thrustMagnitudeWire);

//        new TurretVisualiserController(engineEvents, ship, turret, ComponentPaths.BasicTurretComponent);
//        new ScannerVisualiserController(engineEvents, ship, scanner, ComponentPaths.BasicScannerComponent);
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

        new AnalogueConstant(ship, 5.0f, stallDistWire);
        new AnalogueConstant(ship, 0.02f, thrustMangnitudeWire);
        new AnalogueConstant(ship, 180.0f, negativeBearingWire);
        new AMinusB(brain, ship, world, bearingWire, negativeBearingWire, finalBearingWire);
        new ASuppressB(brain, ship, world, logicOutputWire, thrustMangnitudeWire, finalThrustWire);
        new AGreaterThanB(brain, ship, world, rangeWire, stallDistWire, logicOutputWire);
        new BasicScanner(ship, rangeWire, bearingWire);
        new OmniThruster(ship, finalBearingWire, finalThrustWire);
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

        new BasicScanner(ship, distWire, bearingWire);

        //Thrust calculations
        new AnalogueConstant(ship, 0.5f, constDistWire);
        new AMinusB(brain, ship, world, distWire, constDistWire, errorWire);
        new AnalogueConstant(ship, 0.01f, distScalingWire);
        new ATimesB(ship, errorWire, distScalingWire, distThrustWire);
        new AnalogueConstant(ship, 0.01f, orbitThrustWire);
        new AAddB(brain, ship, world, distThrustWire, orbitThrustWire, netThrustWire);

        //Bearing calculations
        new AnalogueConstant(ship, 90.0f, orbitBearing);
        new AAddB(brain, ship, world, orbitBearing, bearingWire, netBearingWire);

        new OmniThruster(ship, netBearingWire, netThrustWire);
    }
}

internal class PassiveChip : ShipChip
{
    public void Setup(EngineEvents engineEvents, Ship ship, World world, Brain brain)
    {
    }
}
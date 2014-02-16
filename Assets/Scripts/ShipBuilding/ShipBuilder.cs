using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.ShipBuilding.Definitions;
using Assets.Scripts.ShipLoader.ShipLoading;
using Assets.Scripts.Visualisation.NewStyle;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.ShipLoader
{
    static class ShipBuilder
    {
        public static Ship Make(EngineEvents engineEvents, World world, ShipDefinition shipDefinition)
        {
            var simulation = new Simulation(engineEvents);
//            var shipView 
            var digitalWires = new Dictionary<int, DigitalWire>();
            var analogueWires = new Dictionary<int, AnalogueWire>();
            var modules = new Dictionary<int, IModule>();
//            List<Component> components;

            foreach (AnalogueWireDefinition wireDef in shipDefinition.AnalogueWireDefinitions)
            {
                analogueWires.Add(wireDef.Id, new AnalogueWire(simulation));
            }

            foreach (DigitalWireDefinition wireDef in shipDefinition.DigitalWireDefinitions)
            {
                digitalWires.Add(wireDef.Id, new DigitalWire(simulation));
            }

            foreach (HardpointDefinition hardpointDef in shipDefinition.HardpointDefinitions)
            {
                modules.Add(hardpointDef.Id, BuildHardpoint(hardpointDef.HardpointType, hardpointDef.ModuleType));
            }

            throw new NotImplementedException();
//            var ship = new Ship(engineEvents, world, )
        }

        private static GameObject BuildShipView(HullType hullType)
        {
            switch (hullType)
            {
                case HullType.BasicShip:
                    return Object.Instantiate(Resources.Load<GameObject>(ComponentPaths.BasicShip)) as GameObject;
                default:
                    return null;
            }
        }

        private static Component BuildComponent(ComponentType hullType, List<int> inputWireIds, List<int> outputWireIds, int? hardpointId)
        {
            throw new NotImplementedException();
        }

        //Hardpoint....
        /**
         * 1. Instantiate the requried prefab
         * 2. Add the required module
         * 2. Inject component refs as necessary
         **/

        private static IModule BuildHardpoint(HardpointType hardpointType, ModuleType moduleType)
        {
            var hardpoint = Object.Instantiate(Resources.Load<GameObject>(ConvertHardpointTypeToComponentPath(hardpointType))) as GameObject;
            if (hardpoint != null)
            {
                var module = hardpoint.AddComponent<TurretModule>() as IModule;
            }
        }

        private static string ConvertHardpointTypeToComponentPath(HardpointType hardpointType)
        {
             switch (hardpointType)
            {
                case HardpointType.LazerTurret:
                    return ComponentPaths.BasicShip;
                default:
                    return null;
            }
        }

    }
}

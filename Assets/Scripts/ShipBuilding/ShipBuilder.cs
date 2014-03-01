using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ShipBuilding.Definitions;
using Assets.Scripts.ShipLoader.ShipLoading;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;
using Assets.Scripts.Visualisation.NewStyle;
using UnityEngine;
using Component = Assets.Scripts.Simulation.Components.Component;
using Object = UnityEngine.Object;

//TODO - Replace switch case with reflection.
//TODO - Add lots of helpful exceptions for possible nulls. Will help avoid crazy people.
//TODO - Remove evil
namespace Assets.Scripts.ShipBuilding
{
    internal static class ShipBuilder
    {
        private static int numShips;
        private const float AnalogueConst = 0.1f;

        public static void Make(EngineEvents engineEvents, World world, ShipDefinition shipDefinition, int team, float positionX, float positionY)
        {
            var brain = new Brain();
            var ship = new Ship(engineEvents, brain, world, numShips, team, positionX, positionY);

            var wires = BuildWires(shipDefinition.WireDefinitions);
            var componentViews = BuildComponentViews(shipDefinition.HardpointDefinitions);
            var components = BuildComponents(ship, shipDefinition.ComponentDefinitions, wires, componentViews);
            
            BuildShipView(ship, shipDefinition.ShipViewType);

            brain.Wires = wires.Values.ToList();
            brain.Components = components;

            numShips++;
        }

        private static Dictionary<int, IWire> BuildWires(IEnumerable<WireDefinition> wireDefinitions)
        {
            var wires = new Dictionary<int, IWire>();

            foreach (var wireDef in wireDefinitions)
            {
                switch (wireDef.WireType)
                {
                    case WireType.Analogue:
                        wires.Add(wireDef.Id, new AnalogueWire());
                        break;
                    case WireType.Digital:
                        wires.Add(wireDef.Id, new DigitalWire());
                        break;
                }
            }

            return wires;
        }

        private static Dictionary<int, IComponentView> BuildComponentViews(IEnumerable<HardpointDefinition> hardpointDefinitions)
        {
            return hardpointDefinitions.ToDictionary(hardpointDef => hardpointDef.Id, hardpointDef => BuildComponentView(hardpointDef.HardpointType, hardpointDef.ComponentViewType));
        }

        private static IComponentView BuildComponentView(HardpointType hardpointType, ComponentViewType componentViewType)
        {
            var hardpoint = Object.Instantiate(Resources.Load<GameObject>(ComponentPaths.HardpointPath + hardpointType)) as GameObject;

            switch (componentViewType)
            {
                case ComponentViewType.Turret:
                    return hardpoint.AddComponent<TurretComponentView>();
                case ComponentViewType.Scanner:
                    return hardpoint.AddComponent<ScannerComponentView>();
                default:
                    throw new ArgumentException("ComonentViewType: " + componentViewType + " is not valid");
            }
        }

        private static List<Component> BuildComponents(Ship ship, IEnumerable<ComponentDefinition> componentDefinitions, IDictionary<int, IWire> wires, Dictionary<int, IComponentView> componentViews)
        {
            var components = new List<Component>();

            foreach (var componentDefinition in componentDefinitions)
            {
                var component = BuildComponent(ship, componentDefinition.ComponentType, componentDefinition.WireIds, wires);
                InjectIntoComponentView(ship, component, componentDefinition.ComponentViewId, componentViews);
                components.Add(component);
            }

            return components;
        }

        private static Component BuildComponent(Ship ship, ComponentType componentType, IList<int> wireIds, IDictionary<int, IWire> wires)
        {
            switch (componentType)
            {
                case ComponentType.And:
                    return new And(ship, wires[wireIds[0]] as DigitalWire, wires[wireIds[1]] as DigitalWire, wires[wireIds[2]] as DigitalWire);
                case ComponentType.Or:
                    return new Or(ship, wires[wireIds[0]] as DigitalWire, wires[wireIds[1]] as DigitalWire, wires[wireIds[2]] as DigitalWire);
                case ComponentType.AnalogueConstant:
                    return new AnalogueConstant(ship, AnalogueConst, wires[wireIds[0]] as AnalogueWire);
                case ComponentType.BasicScanner:
                    return new BasicScanner(ship, wires[wireIds[0]] as AnalogueWire, wires[wireIds[1]] as AnalogueWire);
                case ComponentType.BasicTurret:
                    return new BasicTurret(ship, wires[wireIds[0]] as AnalogueWire);
                case ComponentType.OmniThruster:
                    return new OmniThruster(ship, wires[wireIds[0]] as AnalogueWire, wires[wireIds[1]] as AnalogueWire);
                default:
                    throw new ArgumentException("Component type: " + componentType + " not recognised");
            }
        }

        private static void InjectIntoComponentView(Ship ship, Component component, int? componentViewId, Dictionary<int, IComponentView> componentViews)
        {
            if (componentViewId != null)
            {
                componentViews[componentViewId.Value].Initialize(ship, component);
            }
        }

        private static void BuildShipView(Ship ship, ShipViewType shipViewType)
        {
            var shipGameObject = Object.Instantiate(Resources.Load<GameObject>(ComponentPaths.ShipsPath + shipViewType)) as GameObject;
            var shipView = shipGameObject.AddComponent<ShipView>();
            shipView.Initialize(ship);
        }
    }
}
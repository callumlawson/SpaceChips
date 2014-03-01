using System;
using System.Collections.Generic;
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
namespace Assets.Scripts.ShipBuilding
{
    internal static class ShipBuilder
    {
        private static int numShips;

        public static void Make(EngineEvents engineEvents, World world, ShipDefinition shipDefinition, int team, float positionX, float positionY)
        {
            var wires = new Dictionary<int, IWire>();
            var componentViews = new Dictionary<int, IComponentView>();
            var brain = new Brain();
            var ship = new Ship(engineEvents, brain, world, numShips, team, positionX, positionY);

            BuildWires(shipDefinition.WireDefinitions, wires);
            BuildComponentViews(shipDefinition.HardpointDefinitions, componentViews);
            BuildComponents(ship, shipDefinition.ComponentDefinitions, wires, componentViews);
            BuildShipView(ship, shipDefinition.ShipViewType);

            numShips++;
        }

        private static void BuildWires(IEnumerable<WireDefinition> wireDefinitions, Dictionary<int, IWire> wires)
        {
            foreach (WireDefinition wireDef in wireDefinitions)
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
        }

        private static void BuildComponentViews(IEnumerable<HardpointDefinition> hardpointDefinitions, Dictionary<int, IComponentView> componentViews)
        {
            foreach (HardpointDefinition hardpointDef in hardpointDefinitions)
            {
                componentViews.Add(hardpointDef.Id, BuildHardpoint(hardpointDef.HardpointType, hardpointDef.ComponentViewType));
            }
        }

        private static IComponentView BuildHardpoint(HardpointType hardpointType, ComponentViewType componentViewType)
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

        private static void BuildComponents(Ship ship, List<ComponentDefinition> componentDefinitions , Dictionary<int, IWire> wires, Dictionary<int, IComponentView> componentViews)
        {
            foreach (var componentDefinition in componentDefinitions)
            {
                BuildComponent(ship, componentDefinition.ComponentType, componentDefinition.WireIds, componentDefinition.ComponentViewId, wires, componentViews);
            }
        }

        private static void BuildComponent(Ship ship, ComponentType componentType, List<int> wireIds, int? componentViewId, Dictionary<int, IWire> wires, Dictionary<int, IComponentView> componentViews)
        {
            switch (componentType)
            {
                case ComponentType.And:
                    InjectIntoComponentView(ship, new And(ship, wires[wireIds[0]] as DigitalWire, wires[wireIds[1]] as DigitalWire, wires[wireIds[2]] as DigitalWire), componentViewId, componentViews);
                    break;
                case ComponentType.Or:
                    InjectIntoComponentView(ship, new Or(ship, wires[wireIds[0]] as DigitalWire, wires[wireIds[1]] as DigitalWire, wires[wireIds[2]] as DigitalWire), componentViewId, componentViews);
                    break;
                case ComponentType.AnalogueConstant:
                    InjectIntoComponentView(ship, new AnalogueConstant(ship, 1.0f, wires[wireIds[0]] as AnalogueWire), componentViewId, componentViews);
                    break;
                case ComponentType.BasicScanner: 
                    InjectIntoComponentView(ship, new BasicScanner(ship, wires[wireIds[0]] as AnalogueWire,  wires[wireIds[0]] as AnalogueWire), componentViewId, componentViews);
                    break;
                case ComponentType.BasicTurret:
                    InjectIntoComponentView(ship, new BasicTurret(ship, wires[wireIds[0]] as AnalogueWire), componentViewId, componentViews);
                    break;
                case ComponentType.OmniThruster:
                    InjectIntoComponentView(ship, new OmniThruster(ship, wires[wireIds[0]] as AnalogueWire, wires[wireIds[1]] as AnalogueWire), componentViewId, componentViews);
                    break;
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
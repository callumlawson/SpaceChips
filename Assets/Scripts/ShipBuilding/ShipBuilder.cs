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

namespace Assets.Scripts.ShipLoader
{
    internal static class ShipBuilder
    {
        private static int numShips;

        public static Ship Make(EngineEvents engineEvents, World world, ShipDefinition shipDefinition, int team, float positionX, float positionY)
        {
            //Only ship has world
            //Comps have ship - queries via ship
            //Ship has interface for damage
            var wires = new Dictionary<int, IWire>();
            var componentViews = new Dictionary<int, IComponentView>();

            BuildWires(shipDefinition.WireDefinitions, wires);

            BuildComponentViews(shipDefinition.HardpointDefinitions, componentViews);

            var brain = new Brain();

            var ship = new Ship(engineEvents, brain, world, numShips, team, positionX, positionY);

            BuildComponents(ship, shipDefinition.ComponentDefinitions, wires, componentViews);

            BuildShipView(ship, shipDefinition.ShipViewType);

            numShips++;
            return ship;
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
            //TODO - callum - add map or reflection from component view type
            return hardpoint.AddComponent<TurretComponentView>();
        }

        private static void BuildComponents(Ship ship, List<ComponentDefinition> componentDefinitions , Dictionary<int, IWire> wires, Dictionary<int, IComponentView> componentViews)
        {
            foreach (var componentDefinition in componentDefinitions)
            {
                BuildComponent(ship, componentDefinition.ComponentType, componentDefinition.WireIds, componentDefinition.ComponentViewId, wires, componentViews);
            }
        }

        //Just wire ids in order?
        private static void BuildComponent(Ship ship, ComponentType componentType, List<int> wireIds, int? componentViewId, Dictionary<int, IWire> wires, Dictionary<int, IComponentView> componentViews)
        {
            switch (componentType)
            {
                case ComponentType.AND:
                    InjectIntoComponentViews(ship, new And(ship, wires[wireIds[0]] as DigitalWire, wires[wireIds[1]] as DigitalWire, wires[wireIds[2]] as DigitalWire), componentViewId, componentViews);
                    break;
                case ComponentType.OR:
                    InjectIntoComponentViews(ship, new Or(ship, wires[wireIds[0]] as DigitalWire, wires[wireIds[1]] as DigitalWire, wires[wireIds[2]] as DigitalWire), componentViewId, componentViews);
                    break;
            }
        }

        private static void InjectIntoComponentViews(Ship ship, Component component, int? componentViewId, Dictionary<int, IComponentView> componentViews)
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

        //Hardpoint....

        /**
         * 1. Instantiate the requried prefab
         * 2. Add the required module
         * 2. Inject component refs as necessary
         **/
    }
}
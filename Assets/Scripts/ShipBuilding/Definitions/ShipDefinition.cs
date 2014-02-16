using System.Collections.Generic;
using Assets.Scripts.ShipBuilding.Definitions;

namespace Assets.Scripts.ShipLoader.ShipLoading
{
    public enum HullType
    {
        BasicShip
    }

    public class ShipDefinition
    {
        public HullType HullType;
        public List<HardpointDefinition> HardpointDefinitions;
        public List<ComponentDefinition> ComponentDefinitions;
        public List<AnalogueWireDefinition> AnalogueWireDefinitions;
        public List<DigitalWireDefinition> DigitalWireDefinitions;
    }
}

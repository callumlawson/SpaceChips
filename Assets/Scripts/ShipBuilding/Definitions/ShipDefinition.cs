using System.Collections.Generic;
using Assets.Scripts.ShipBuilding.Definitions;

namespace Assets.Scripts.ShipLoader.ShipLoading
{
    public enum ShipViewType
    {
        BasicShip
    }

    public class ShipDefinition
    {
        public ShipViewType ShipViewType;
        public List<HardpointDefinition> HardpointDefinitions;
        public List<ComponentDefinition> ComponentDefinitions;
        public List<WireDefinition> WireDefinitions;
    }
}

using System.Collections.Generic;

namespace Assets.Scripts.ShipLoader.ShipLoading
{
    public enum ComponentType
    {
        AND,
        OR
    }

    public class ComponentDefinition
    {
        public ComponentType ComponentType;
        public int? ComponentViewId;
        public List<int> WireIds;
    }
}
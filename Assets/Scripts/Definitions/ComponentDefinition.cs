using System.Collections.Generic;

namespace Assets.Scripts.Definitions
{
    public enum ComponentType
    {
        And,
        Or,
        AnalogueProbe,
        AnalogueConstant,
        OmniThruster,
        BasicScanner,
        BasicTurret
    }

    public class ComponentDefinition
    {
        public ComponentDefinition(ComponentType componentType, int? componentViewId, List<int> wireIds)
        {
            ComponentType = componentType;
            ComponentViewId = componentViewId;
            WireIds = wireIds;
        }

        public ComponentType ComponentType;
        public int? ComponentViewId;
        public List<int> WireIds;
    }
}
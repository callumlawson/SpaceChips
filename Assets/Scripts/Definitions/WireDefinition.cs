
using Assets.Scripts.Definitions;

namespace Assets.Scripts.Definitions
{
//    public enum WireType
//    {
//        Analogue,
//        Digital
//    }

    public class WireDefinition
    {
        public WireDefinition(WireType wireType, int id)
        {
            WireType = wireType;
            Id = id;
        }

//        public WireType WireType;
        public int Id;
    }
}

/**
{
    "Wires": [{ WireType:dlksajfdslj.wires.AnalogueWire, Id:aaa}]
}
**/

namespace Assets.Scripts.ShipBuilding.Definitions
{
    public enum WireType
    {
        Analogue,
        Digital
    }

    public class WireDefinition
    {
        public WireDefinition(WireType wireType, int id)
        {
            WireType = wireType;
            Id = id;
        }

        public WireType WireType;
        public int Id;
    }
}

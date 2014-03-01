using UnityEngine;

namespace Assets.Scripts.ShipLoader.ShipLoading
{
    public enum HardpointType
    {
        LazerTurret,
        //Could have KineticTurret etc
        BasicScanner
    }

    public enum ComponentViewType
    {
        Turret,
        Scanner
    }

    public class HardpointDefinition
    {
        public HardpointType HardpointType;
        public ComponentViewType ComponentViewType;
        public int Id;
        public Vector2 Position;

        public HardpointDefinition(HardpointType hardpointType, ComponentViewType componentViewType, int id, Vector2 position)
        {
            HardpointType = hardpointType;
            ComponentViewType = componentViewType;
            Id = id;
            Position = position;
        }
    }
}

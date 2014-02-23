using UnityEngine;

namespace Assets.Scripts.ShipLoader.ShipLoading
{
    public enum HardpointType
    {
        LazerTurret,
        BasicScanner
    }

    public enum ComponentViewType
    {
        Turret    
    }

    public class HardpointDefinition
    {
        public HardpointType HardpointType;
        public ComponentViewType ComponentViewType;
        public int Id;
        public Vector2 Position;
    }
}

using UnityEngine;

namespace Assets.Scripts.ShipLoader.ShipLoading
{
    public enum HardpointType
    {
        LazerTurret,
        BasicScanner
    }

    public enum ModuleType
    {
        Turret    
    }

    public class HardpointDefinition
    {
        public HardpointType HardpointType;
        public ModuleType ModuleType;
        public int Id;
        public Vector2 Position;
    }
}

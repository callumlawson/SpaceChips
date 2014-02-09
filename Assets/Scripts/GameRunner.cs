using UnityEngine;

internal class GameRunner : MonoBehaviour
{
  /**
  *Notes:
  *Concentrate on "has a" not "is a" relationships
  *Use JointJS for gui.
  **/ 

    private readonly World world = new World();
    private EngineEvents engineEvents;

    private void Start()
    {
        SetupSingletons();
        SetupWorld();
    }

    private void SetupSingletons()
    {
        engineEvents = gameObject.AddComponent<EngineEvents>();
    }

    private void SetupWorld()
    {
        CreateShip(new BasicChip(), 2, 3);
        CreateShip(new CowardChip(), -1, -3);
        CreateShip(new BasicChip(), 0, 0);
        CreateShip(new OrbitChip(), 5, 7);
    }

    private void CreateShip(ShipChip shipChip, float positionX, float positionY)
    {
        new Ship(engineEvents, world, shipChip, 0, positionX, positionY);
    }

 
}
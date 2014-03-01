using Assets.Scripts.ShipBuilding;
using Assets.Scripts.ShipLoader.ShipLoading;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;

internal class GameRunner : MonoBehaviour
{
    /**
    *Notes:
    *Concentrate on "has a" not "is a" relationships
    *Use JointJS for gui.
    **/
    //If compeonents were given more uniform constuctors I could reflect on them to build editor proxy.
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
        CreateShip(ShipDefs.BasicShip(), 0, 5, 5);
        CreateShip(ShipDefs.PassiveShip(), 1, 0, 0);
    }

    private void CreateShip(ShipDefinition shipDef, int team, float positionX, float positionY)
    {
        ShipBuilder.Make(engineEvents, world, shipDef, team, positionX, positionY);
    }
}
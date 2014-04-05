using Assets.Scripts.Definitions;
using Assets.Scripts.Editor;
using Assets.Scripts.ShipBuilding;
using Assets.Scripts.Simulation.State;
using UnityEngine;

internal class GameRunner : MonoBehaviour
{
    /**
    *Notes:
    *Concentrate on "has a" not "is a" relationships
    *Use JointJS for gui.
    **/
    //If compeonents were given more uniform constuctors I could reflect on them to build editor proxy.
    private readonly ChipEditor editor = new ChipEditor();
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
        CreateShip(ShipDefs.BasicShip(), 1, 3, 5);
        CreateShip(ShipDefs.BasicShip(), 2, 11, -2);
        CreateShip(ShipDefs.PassiveShip(), 3, 1, -4);
    }

    private void CreateShip(ShipDefinition shipDef, int team, float positionX, float positionY)
    {
        ShipBuilder.Make(engineEvents, world, shipDef, team, positionX, positionY);
    }
}
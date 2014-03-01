using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.GameState;

namespace Assets.Scripts.Visualisation.NewStyle
{
    public interface IComponentView
    {
        void Initialize(Ship ship, Component basicTurret);
    }
}

using Assets.Scripts.Simulation.GameState;
using UnityEngine;
using Component = Assets.Scripts.Simulation.Components.Component;

namespace Assets.Scripts.Visualisation.NewStyle
{
    internal abstract class TypedComponentView<TComponentType> : MonoBehaviour, IComponentView
    {
        protected TComponentType componentModel;
        protected Ship ship;

        public void Initialize(Ship ship, Component basicTurret)
        {
            //Shenaggans + cast
            Initialize();
        }

        protected abstract void Initialize();
    }
}
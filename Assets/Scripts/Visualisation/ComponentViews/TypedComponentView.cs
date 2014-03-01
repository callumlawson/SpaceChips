using Assets.Scripts.Simulation.GameState;
using UnityEngine;
using Component = Assets.Scripts.Simulation.Components.Component;

namespace Assets.Scripts.Visualisation.NewStyle
{
    internal abstract class TypedComponentView<TComponentType> : MonoBehaviour, IComponentView where TComponentType : class
    {
        protected TComponentType ComponentModel;
        protected Ship Ship;

        public void Initialize(Ship ship, Component component)
        {
            Ship = ship;
            ComponentModel = component as TComponentType;
            component.OnComponentDestroyed += DestroyComponentView;
            Initialize();
        }

        private void DestroyComponentView()
        {
            Destroy(gameObject);
        }

        protected abstract void Initialize();
    }
}
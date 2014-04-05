using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.State;
using UnityEngine;

namespace Assets.Scripts.Visualisation.NewStyle
{
    internal abstract class TypedComponentView<TComponentType> : MonoBehaviour, IComponentView where TComponentType : class
    {
        protected TComponentType ComponentModel;
        protected Ship Ship;

        public void Initialize(Ship ship, Chip component)
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
using System;

namespace Assets.Scripts.Simulation.Components
{
    public abstract class Component
    {
        public event Action OnComponentDestroyed;
        //TODO rename as component is already a unity class
        protected Component()
        {
        }

        public void Destroy()
        {
            if (OnComponentDestroyed != null)
            {
                OnComponentDestroyed();
            }
        }

        public abstract void OnClockEdge();
    }
}
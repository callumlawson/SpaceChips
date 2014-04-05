using System;

namespace Assets.Scripts.Simulation.Components
{
    //TODO rename as component is already a unity class
    public abstract class Chip
    {
        public event Action OnComponentDestroyed;

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
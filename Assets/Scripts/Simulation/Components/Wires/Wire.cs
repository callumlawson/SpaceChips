namespace Assets.Scripts.Simulation.Components.Wires
{
    public abstract class Wire<T> : IWire
    {
        private T nextSignalValue;
        private T currentSignalValue;
        public T SignalValue {
            get { return currentSignalValue; }
            set { nextSignalValue = value; }
        }

        public void AfterClockEdge()
        {
            currentSignalValue = nextSignalValue;
        }
    }
}
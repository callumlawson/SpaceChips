abstract class Wire<T>
{
    private T nextSignalValue;
    private T currentSignalValue;
    public T SignalValue {
        get { return currentSignalValue; }
        set { nextSignalValue = value; }
    }

    protected Wire(Simulation simulation)
    {
        simulation.AfterClockEdge += AfterClockEdge;
    }

    public void AfterClockEdge()
    {
        currentSignalValue = nextSignalValue;
    }
}
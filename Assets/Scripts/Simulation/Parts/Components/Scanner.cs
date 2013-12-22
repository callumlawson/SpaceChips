using System;

internal class Scanner : Component
{
    private readonly Wire bearingOutput;
    private readonly Random random = new Random();
    private readonly Wire rangeOutput;
    private World world;

    public Scanner(Simulation simulation, World world, Wire rangeOutput, Wire bearingOutput) : base(simulation)
    {
        this.world = world;
        this.rangeOutput = rangeOutput;
        this.bearingOutput = bearingOutput;
    }

    public override void OnClockEdge()
    {
        rangeOutput.SignalValue = (float) random.NextDouble()*500.0f;
        bearingOutput.SignalValue = (float) random.NextDouble()*360.0f;
    }
}
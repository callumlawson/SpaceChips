internal class ShipModel
{
    private readonly Simulation simulation;
    public float PositionX;
    public float PositionY;

    public ShipModel(World world, ShipChip shipChip, float initalPositionX, float positionY)
    {
        PositionX = initalPositionX;
        PositionY = positionY;

        simulation = new Simulation();

        shipChip.Setup(this, world, simulation);
    }

    public void StartSimulation()
    {
        simulation.Start();
    }

    public void StopSimulation()
    {
        simulation.Stop();
    }
}
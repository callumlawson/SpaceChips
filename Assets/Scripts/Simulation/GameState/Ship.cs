internal class Ship
{
    private readonly Simulation simulation;
    public float X;
    public float Y;
    public float RotationInDegrees;

    public int ShipId;
    private static int shipCount;

    public Ship(World world, ShipChip shipChip, float initalX, float initalY, float rotationInDegrees)
    {
        shipCount += 1;
        ShipId = shipCount;

        RotationInDegrees = rotationInDegrees;
        X = initalX;
        Y = initalY;

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
using UnityEngine;

internal class Ship
{
    public float X;
    public float Y;
    public float RotationInDegrees;
    public int ShipId;
    public bool IsAlive = true;

    private static int shipCount;
    private readonly Simulation simulation;
    private readonly World world;
    private const float CollisionDistance = 0.2f;

    public Ship(World world, ShipChip shipChip, float initalX, float initalY, float rotationInDegrees)
    {
        this.world = world;
        shipCount += 1;
        ShipId = shipCount;

        RotationInDegrees = rotationInDegrees;
        X = initalX;
        Y = initalY;

        simulation = new Simulation();
        simulation.ClockEdge += UpdateState;
        shipChip.Setup(this, world, simulation);
        simulation.Start();
    }

    public void Kill()
    {
        IsAlive = false;
    }

    private void UpdateState()
    {
        CheckForCollision();
        CheckForDeath();
    }

    private void CheckForCollision()
    {
        var nearestShip = world.GetNearestShip(this);
        if (nearestShip != null)
        {
            if (SpaceMath.DistanceBetweenTwoPoints(X, Y, nearestShip.X, nearestShip.Y) <= CollisionDistance)
            {
                nearestShip.Kill();
                Kill();
            }
        }
    }

    private void CheckForDeath()
    {
        if (!IsAlive)
        {
            Debug.Log("Ship Id: " + ShipId + " has been destroyed");
            simulation.Stop();
        }
    }
}
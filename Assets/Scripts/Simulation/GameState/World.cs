using System.Collections.Generic;

internal class World
{
    private readonly List<Ship> ships = new List<Ship>();

    public void AddShip(Ship ship)
    {
        ships.Add(ship);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class World
{
    private readonly List<Ship> ships = new List<Ship>();

    public void AddShip(Ship ship)
    {
        ships.Add(ship);
    }

    public Ship GetNearestShip(Ship shipDoingQuery)
    {
        return ships.Where(ship => ship.ShipId != shipDoingQuery.ShipId).OrderBy(ship => SpaceMath.DistanceBetweenTwoPoints(shipDoingQuery.X, shipDoingQuery.Y, ship.X, ship.Y)).FirstOrDefault();
    }
}
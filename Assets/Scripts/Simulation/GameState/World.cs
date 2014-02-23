﻿using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Simulation.GameState;

public class World
{
    private readonly List<Ship> ships = new List<Ship>();

    public void AddShip(Ship ship)
    {
        ships.Add(ship);
    }

    public void RemoveShip(Ship ship)
    {
        ships.Remove(ship);
    }

    public List<Ship> GetShips()
    {
        return ships;
    }

    //These should be methods on a ship not on the world
    public Ship GetNearestShip(Ship shipDoingQuery)
    {
        return ships.Where(ship => ship.ShipId != shipDoingQuery.ShipId)
            .OrderBy(ship => SpaceMath.DistanceBetweenTwoPoints(shipDoingQuery.PositionX, shipDoingQuery.PositionY, ship.PositionX, ship.PositionY))
            .FirstOrDefault();
    }

    public Ship GetNearestShipOnTeam(Ship shipDoingQuery, int team)
    {
        return ships.Where(ship => ship.ShipId != shipDoingQuery.ShipId)
            .OrderBy(ship => SpaceMath.DistanceBetweenTwoPoints(shipDoingQuery.PositionX, shipDoingQuery.PositionY, ship.PositionX, ship.PositionY))
            .FirstOrDefault(ship => ship.Team == team);
    }

    public Ship GetNearestShipNotOnTeam(Ship shipDoingQuery, int team)
    {
        return ships.Where(ship => ship.ShipId != shipDoingQuery.ShipId)
            .OrderBy(ship => SpaceMath.DistanceBetweenTwoPoints(shipDoingQuery.PositionX, shipDoingQuery.PositionY, ship.PositionX, ship.PositionY))
            .FirstOrDefault(ship => ship.Team != team);
    }

    public Ship GetShipByShipId(int shipId)
    {
        return ships.FirstOrDefault(ship => ship.ShipId == shipId);
    }
}
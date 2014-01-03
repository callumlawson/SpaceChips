using System.Collections.Generic;
using System.Linq;

internal class World
{
    private readonly List<Ship> ships = new List<Ship>();

    public void AddShip(Ship ship)
    {
        ships.Add(ship);
    }

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
}
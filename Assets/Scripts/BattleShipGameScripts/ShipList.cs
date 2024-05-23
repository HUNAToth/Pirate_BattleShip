using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipList 
{
    public List<ShipType> ships = new List<ShipType>();
    public ShipList()
    {
        ships.Add(new ShipType("Carrier", 5));
        ships.Add(new ShipType("Battleship", 4));
        ships.Add(new ShipType("Cruiser", 3));
        ships.Add(new ShipType("Submarine", 2));
        ships.Add(new ShipType("Submarine", 2));
        ships.Add(new ShipType("Destroyer", 1));
        ships.Add(new ShipType("Destroyer", 1));
    }
     
}

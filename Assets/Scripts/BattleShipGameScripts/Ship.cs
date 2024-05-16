using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ship 
{
    public string name;
    public int size;
    public bool isSunk;

[SerializeField]
    public ShipPart[] parts;

    public Ship(string name, ShipPart[] parts)
    {
        this.name = name;
        this.isSunk = false;
        this.parts = parts;
    }

    public bool IsSunk()
    {
        return isSunk;
    }

    public void ExecuteSink()
    {
        Debug.Log("Ship " + name + " has been sunk!");
        isSunk = true;
        foreach(ShipPart part in parts)
        {
            part.isSunk = true;
        }
    }   

}

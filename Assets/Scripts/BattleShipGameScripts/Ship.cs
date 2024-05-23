using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ship 
{
    public string name;
    public int size;
    public bool isSunk;

    public int hits = 0;

    [SerializeField]
    public ShipPart[] parts;

    public Ship(string name, ShipPart[] parts)
    {
        this.name = name;
        this.isSunk = false;
        this.parts = parts;
        this.size = parts.Length;
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

    public void Hit()
    {
        UIManager uIManager = GameObject.Find("GAMEMANAGER").GetComponent<UIManager>();
        uIManager.DisplayTextMessage("Ship Hit!");
        hits++;
        if(hits == parts.Length)
        {
            ExecuteSink();        
            uIManager.DisplayTextMessage("Ship sunk!");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int GridXSize = 10;
    public int GridYSize = 10;
    // Start is called before the first frame update
    public GameObject CellPrefab;
    public GameObject cam;
    public GameObject[,] grid;
    public int currShipCount = 0;
    public ShipList shipList = new ShipList();

    [SerializeField]
    public Ship[] ships; 
    public Ship[] remainingShips;

    public GameObject shipPrefab;

    void Start()
    {
        this.InitiateGrid(GridXSize, GridYSize);
        ships = new Ship[shipList.ships.Count];
        this.PopulateGrid();
        this.currShipCount = shipList.ships.Count;
        remainingShips = ships;

    }

    // Update is called once per frame
    void Update()
    {
        FilterRemainingShips();
    }


    void InitiateGrid(int GridXSize, int GridYSize){

        grid = new GameObject[GridXSize, GridYSize];
        //load an initialize the grid, by initializing cells, and setting their parent to the grid
        for (int i = 0; i < GridXSize; i++)
        {
            for (int j = 0; j < GridYSize; j++)
            {
                GameObject cell = Instantiate(CellPrefab, new Vector3(i*1.5f, j*1.5f, 0), Quaternion.identity);
                cell.transform.parent = this.transform;
                cell.name = "Cell_" + i + "_" + j;
                cell.transform.position = new Vector3(i, 0, j);
                cell.GetComponent<CellManager>().isOccupied = false;
                cell.GetComponent<CellManager>().isHighlighted = false;
                grid[i, j] = cell;
            }
        }

    }


    void PopulateGrid()
    {

        //populate the grid with N ships
        if (shipPrefab == null)
        {
            return;
        }

        for (int i = 0; i < shipList.ships.Count; i++)
        {
            int shipSize = shipList.ships[i].size;

            //get a random location for the ship
            //following format: [[4,1],[4,2],[4,3],[4,4],...]
            List<int[]> availableLocation = FindPlaceForShip(shipSize);
            for(int j = 0; j < availableLocation.Count; j++)
            {
                Debug.Log("Available location: " + availableLocation[j][0] + ", " + availableLocation[j][1]);
            }


            ShipPart[] partList = new ShipPart[shipSize];
            for (int j = 0; j < shipSize; j++)
            {
                partList[j] = transform.Find("Cell_" + availableLocation[j][0] + "_" + availableLocation[j][1]).GetComponent<ShipPart>();
            }
            Ship shipVar = new Ship(shipList.ships[i].name, partList);

            Debug.Log("Ship " + shipVar.name + " created!");
            ships[i] = shipVar;



            foreach (ShipPart part in shipVar.parts)
            {
                part.parent = shipVar;
            }
                int x = availableLocation[0][0];
                int y = availableLocation[0][1]; 
                GameObject ship = Instantiate(shipPrefab, new Vector3(0, 0, -0.5f), Quaternion.identity);
                ship.transform.SetParent(grid[x, y].transform);
                ship.name = "Ship_" +x + "_" + y;
                ship.transform.position = new Vector3(
                    grid[x, y].transform.position.x,
                    grid[x, y].transform.position.y + 0.5f,
                    grid[x, y].transform.position.z - 0.5f
                );
                ship.SetActive(false);

            for (int j = 0; j < shipSize; j++)
            {
                x = availableLocation[j][0];
                y = availableLocation[j][1];
                grid[x,y].GetComponent<CellManager>().isOccupied = true;
                grid[x,y].GetComponent<CellManager>().occupiedBy = ship;
            }
        }
    }

    List<int[]> FindPlaceForShip(int shipSize)
    {
        List<int[]> shipLocation = new List<int[]>();

        int posX = Random.Range(0, GridXSize);
        int posY = Random.Range(0, GridYSize);
        bool hasHorizontalSpaceInGridForShipBody = posX + shipSize < GridXSize;
        bool hasVerticalSpaceInGridForShipBody = posY + shipSize < GridYSize;
        bool isHorizontal = Random.Range(0, 2) >= 1;

        while (grid[posX, posY].GetComponent<CellManager>().isOccupied ||
            (
                (isHorizontal && !hasHorizontalSpaceInGridForShipBody) ||
                (!isHorizontal && !hasVerticalSpaceInGridForShipBody)
            )
        )
        {
           posX = Random.Range(0, GridXSize);
            posY = Random.Range(0, GridYSize);
            hasHorizontalSpaceInGridForShipBody = posX + shipSize < GridXSize;
            hasVerticalSpaceInGridForShipBody = posY + shipSize < GridYSize; 
           
        }
        //start point added
        shipLocation.Add(new int[2] { posX, posY });
     
        int nextX = posX;
        int nextY = posY;

        //check if the next cells are occupied
        bool wereCellsOccupied = false;

        for (int i = 1; i < shipSize; i++)
        {
            if (isHorizontal)
            {
                nextX = posX + i;
                nextY = posY;
            }
            else
            {
                nextX = posX;
                nextY = posY + i;
            }
            if (grid[nextX, nextY].GetComponent<CellManager>().isOccupied)
            {
                wereCellsOccupied = true;
            }
        }

        if (!wereCellsOccupied)
        {
            for (int i = 1; i < shipSize; i++)
            {
                if (isHorizontal)
                {
                    nextX = posX + i;
                }
                else
                {
                    nextY = posY + i;
                }
                shipLocation.Add(new int[2] { nextX, nextY });
            }
        }
        else
        {
            shipLocation = FindPlaceForShip(shipSize);
        }
        return shipLocation;
    }



    public Ship[] getShips()
    {
        return ships;
    }

    public void FilterRemainingShips()
    {
        List<Ship> remainingShipsList = new List<Ship>();
        foreach (Ship ship in ships)
        {
            if (!ship.isSunk)
            {
                remainingShipsList.Add(ship);
            }
        }
        remainingShips = remainingShipsList.ToArray();
    }
    
}

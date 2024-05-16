using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int GridXSize = 5;
    public int GridYSize = 5;
    // Start is called before the first frame update
    public GameObject CellPrefab;
    public GameObject cam;
    public GameObject[,] grid;
    public int currShipCount = 0;
    public ShipList shipList = new ShipList();

    [SerializeField]
    public Ship[] ships;

    public GameObject shipPrefab;

    void Start()
    {

        grid = new GameObject[GridXSize, GridYSize];
        ships = new Ship[shipList.ships.Count];


        //load an initialize the grid, by initializing cells, and setting their parent to the grid
        for (int i = 0; i < GridXSize; i++)
        {
            for (int j = 0; j < GridYSize; j++)
            {
                GameObject cell = Instantiate(CellPrefab, new Vector3(i, j, 0), Quaternion.identity);
                cell.transform.parent = this.transform;
                cell.name = "Cell_" + i + "_" + j;
                cell.transform.position = new Vector3(i, 0, j);
                cell.GetComponent<CellManager>().isOccupied = false;
                cell.GetComponent<CellManager>().isHighlighted = false;
                grid[i, j] = cell;
            }
        }

        this.currShipCount = shipList.ships.Count;

        this.PopulateGrid();

    }

    // Update is called once per frame
    void Update()
    {

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
            List<int[]> availableLocation = PlaceShip(shipSize);
            ShipPart[] partList = new ShipPart[shipSize];
            for (int j = 0; j < shipSize; j++)
            {
                partList[j] = this.transform.Find("Cell_" + i + "_" + j).GetComponent<ShipPart>();
            }
            Ship shipVar = new Ship(shipList.ships[i].name, partList);
            ships[i] = shipVar;
            foreach (ShipPart part in shipVar.parts)
            {
                part.parent = shipVar;
            }

            for (int j = 0; j < shipSize; j++)
            {

                GameObject ship = Instantiate(shipPrefab, new Vector3(0, 0, -0.5f), Quaternion.identity);
                ship.transform.SetParent(this.grid[availableLocation[j][0], availableLocation[j][1]].transform);
                ship.name = "Ship_" + shipVar.parts[j].x + "_" + shipVar.parts[j].y;
                ship.transform.position = new Vector3(
                    this.grid[availableLocation[j][0], availableLocation[j][1]].transform.position.x,
                    this.grid[availableLocation[j][0], availableLocation[j][1]].transform.position.y + 0.5f,
                    this.grid[availableLocation[j][0], availableLocation[j][1]].transform.position.z - 0.5f
                );
                ship.SetActive(false);
                Debug.Log("Ship placed at: " + shipVar.parts[j].x + ", " + shipVar.parts[j].y);
                grid[shipVar.parts[j].x,shipVar.parts[j].y].GetComponent<CellManager>().isOccupied = true;
                grid[shipVar.parts[j].x,shipVar.parts[j].y].GetComponent<CellManager>().occupiedBy = ship;
            }
        }
    }

    public void HighlightCell(int x, int y)
    {
        grid[x, y].GetComponent<CellManager>().isHighlighted = true;
    }
    public void UnHighlightCell(int x, int y)
    {
        grid[x, y].GetComponent<CellManager>().isHighlighted = false;
    }

    public void HitCell(int x, int y)
    {
        //CellManager handles the hit
    }

    List<int[]> PlaceShip(int shipSize)
    {
        Debug.Log("Placing ship of size: " + shipSize);
        List<int[]> shipLocation = new List<int[]>();

        int posX = Random.Range(0, GridXSize);
        int posY = Random.Range(0, GridYSize);
        bool hasHorizontalSpaceInGrid = posX + shipSize < GridXSize;
        bool hasVerticalSpaceInGrid = posY + shipSize < GridYSize;
        bool isHorizontal = Random.Range(0, 2) >= 1;

        while (grid[posX, posY].GetComponent<CellManager>().isOccupied &&
            (
                (isHorizontal && hasHorizontalSpaceInGrid) ||
                (!isHorizontal && hasVerticalSpaceInGrid)
            )
        )
        {
            posX = Random.Range(0, GridXSize);
            posY = Random.Range(0, GridYSize);
            hasHorizontalSpaceInGrid = posX + shipSize < GridXSize;
            hasVerticalSpaceInGrid = posY + shipSize < GridYSize;
        }
        //start point added
        shipLocation.Add(new int[2] { posX, posY });
        Debug.Log("Ship Start location planned to: " + posX + ", " + posY);

        int nextX = 0;
        int nextY = 0;

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
            Debug.Log("Checking cell: " + nextX + ", " + nextY + " for ship part placement");
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
                Debug.Log("Ship location planned to: " + nextX + ", " + nextY);
            }
        }
        else
        {
            Debug.Log("Ship location was occupied, retrying...");
            shipLocation = PlaceShip(shipSize);
        }

        return shipLocation;
    }



    public Ship[] getShips()
    {
        return ships;
    }
}

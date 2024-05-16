using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public bool isGameOver = false;
    public bool isGamePaused = false;
    public Ship[] ships;
    public int hits;
    public int misses;
    public int maxMisses;
    // Start is called before the first frame update
    void Start()
    {
        ships = gridManager.getShips();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
    }
    public void CheckForGameEnd()
    {
        Debug.Log("Checking for Game End");

    }

    public void EndGame()
    {
        Debug.Log("Game Ended");
    }

    public void RestartGame()
    {
        Debug.Log("Game Restarted");
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
    }
}

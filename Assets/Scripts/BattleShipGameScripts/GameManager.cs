using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public bool isGameOver = false;
    public bool isGamePaused = false;
    public Ship[] ships;
    public int hits = 0;
    public int misses = 0;
    public int maxMisses = 0;

    public UIManager uiManager;
    // Start is called before the first frame update

    public void Start()
    {
        ships = gridManager.getShips();
    }

    // Update is called once per frame
    public void Update()
    {
        if(ships == null)
        {
            ships = gridManager.getShips();
        }

        if (isGameOver)
        {
            EndGame();
        }
        else
        {
            CheckForGameEnd();
        }
        
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
    }

    public void CheckForGameEnd()
    {
        if(gridManager.remainingShips.Length == 0)
        {
            isGameOver = true;
        }
       
    }

    public void EndGame()
    {
        Debug.Log("Game Ended");
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        
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

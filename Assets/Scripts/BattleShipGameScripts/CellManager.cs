using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public bool isOccupied = false;
    public bool isHighlighted = false;
    public bool isHit = false;
    public bool isMissed = false;

    public GameObject occupiedBy;

    public GameObject Alert_Hit;
    public GameObject Alert_Miss;
    public GameObject Alert_HighLight;

    public Ship ship;

    public GameManager gameManager;
    public UIManager uiManager;

    // Start is called before the first frame update
    public void Start()
    {
        Alert_Hit = this.transform.Find("Alert_Hit").gameObject;
        Alert_Miss = this.transform.Find("Alert_Miss").gameObject;
        Alert_HighLight = this.transform.Find("Alert_HighLight").gameObject;

        Alert_Hit.SetActive(false);
        Alert_Miss.SetActive(false);
        Alert_HighLight.SetActive(false);

        
       gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
       uiManager = GameObject.Find("GAMEMANAGER").GetComponent<UIManager>();
        
    }

    // Update is called once per frame
    public void Update()
    {
        HitCheck();
        DisplayAlerts();
      
    }


    void HitCheck()
    {
        //check if mouse is clicked
        if (Input.GetMouseButtonDown(0)) {
            if(isHighlighted){
                if(isOccupied){
                    isHit = true;
                    transform.GetComponent<ShipPart>().Hit();
                    gameManager.hits++;
                }else {
                    isMissed = true;
                    gameManager.misses++;
                    uiManager.DisplayTextMessage("Miss!");
                }
            }
        }
    }
    void DisplayAlerts(){
        if(isHit||isMissed) {
            if(isOccupied){
                if(Alert_Hit.activeSelf == false){
                    Alert_Hit.SetActive(true);
                }
            } else {
                if(Alert_Miss.activeSelf == false){
                    Alert_Miss.SetActive(true);
                }
            }
            Alert_HighLight.SetActive(false);
        }else{
            if(isHighlighted && !isHit){
                Alert_HighLight.SetActive(true);
            }else {
                Alert_HighLight.SetActive(false);
            }     
        }    
    }
}

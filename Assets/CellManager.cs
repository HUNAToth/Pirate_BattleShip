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

    // Start is called before the first frame update
    void Start()
    {
        Alert_Hit = this.transform.Find("Alert_Hit").gameObject;
        Alert_Miss = this.transform.Find("Alert_Miss").gameObject;
        Alert_HighLight = this.transform.Find("Alert_HighLight").gameObject;

        Alert_Hit.SetActive(false);
        Alert_Miss.SetActive(false);
        Alert_HighLight.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        HighLightCheck();
        HitCheck();

        DisplayAlerts();
       
    }


    void HitCheck()
    {
        //check if mouse is clicked
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            Vector2 objPos = Camera.main.WorldToScreenPoint(this.transform.position);

            if(Vector2.Distance(mousePos,objPos) < 7 ){
                if(isOccupied){
                    isHit = true;
                    this.transform.GetComponent<ShipPart>().Hit();
                }else {
                    isMissed = true;
                }
            }
        }
    }

    void HighLightCheck()
    {
        //if the x and y of the cell is the same of the mouse position, then highlight the cell
        Vector2 mousePos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Vector2 objPos = Camera.main.WorldToScreenPoint(this.transform.position);
        if(Vector2.Distance(mousePos,objPos) < 7){
            isHighlighted = true;
        }else {
            isHighlighted = false;
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

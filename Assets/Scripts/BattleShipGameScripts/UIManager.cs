using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UIManager : MonoBehaviour
{
    
    public GameManager gameManager;
    public GridManager gridManager;
    public TextMeshProUGUI hitsText;
    public TextMeshProUGUI shipsText;
    public TextMeshProUGUI missesText;
    public TextMeshProUGUI messageText;
    // Start is called before the first frame update

    public Image Ship5Length;
    public TextMeshProUGUI Ship5LengthText;
    public Image Ship4Length;
    public TextMeshProUGUI Ship4LengthText;
    public Image Ship3Length;
    public TextMeshProUGUI Ship3LengthText;
    public Image Ship2Length;
    public TextMeshProUGUI Ship2LengthText;
    public Image Ship1Length;
    public TextMeshProUGUI Ship1LengthText;



    void Start()
    {
        //gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
       // gridManager = GameObject.Find("Grid").GetComponent<GridManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
    }

    public void UpdateGUI()
    {
        hitsText.text = gameManager.hits.ToString();
        missesText.text = gameManager.misses.ToString();
        shipsText.text = gridManager.ships.Length.ToString();
        Ship1LengthText.text = gridManager.remainingShips.Where(x => x.size == 1).Count().ToString();
        Ship2LengthText.text = gridManager.remainingShips.Where(x => x.size == 2).Count().ToString();
        Ship3LengthText.text = gridManager.remainingShips.Where(x => x.size == 3).Count().ToString();
        Ship4LengthText.text = gridManager.remainingShips.Where(x => x.size == 4).Count().ToString();
        Ship5LengthText.text = gridManager.remainingShips.Where(x => x.size == 5).Count().ToString();
        if(Ship1LengthText.text == "0")
        {
            Ship1Length.color = Color.red;
            Ship1LengthText.color = Color.red;
        }
        if(Ship2LengthText.text == "0")
        {
            Ship2Length.color = Color.red;
            Ship2LengthText.color = Color.red;
        }
        if(Ship3LengthText.text == "0")
        {
            Ship3Length.color = Color.red;
            Ship3LengthText.color = Color.red;
        }
        if(Ship4LengthText.text == "0")
        {
            Ship4Length.color = Color.red;
            Ship4LengthText.color = Color.red;
        }
        if(Ship5LengthText.text == "0")
        {
            Ship5Length.color = Color.red;
            Ship5LengthText.color = Color.red;
        }

    }

    public void DisplayTextMessage(string message)
    {
        messageText.text = message;
        //fade out message over 5 seconds
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText(float duration = 3.0f,float startAlpha = 1.0f, float endAlpha = 0.0f) {
        for (float t=0f;t<duration;t+=Time.deltaTime) {
            float normalizedTime = t/duration;
            messageText.color = new Color(1,1,1,Mathf.Lerp(startAlpha,endAlpha,normalizedTime));
            yield return null;
        }
    }
}

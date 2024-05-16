using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShipPart : MonoBehaviour
{
    public int x;
    public int y;
    public bool isHit;
    public bool isSunk;

[SerializeField]
    public Ship parent;

     public GameObject smokePrefab;

    public void Start(){
        isHit = false;
        isSunk = false;
        smokePrefab = this.transform.Find("VolumetricSmoke").gameObject;
    }
    public void Update()
    {
        if(isSunk&&smokePrefab!=null)
        {
            smokePrefab.SetActive(true);      
        }
    }

    public void Hit()
    {
        Debug.Log("ShipPart Hit");
        if(!isHit)
        {
            isHit = true;
        }
    }

}

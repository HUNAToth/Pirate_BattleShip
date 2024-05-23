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
      
    }

    public void Hit()
    {
        if(!isHit)
        {
            isHit = true;
            smokePrefab.SetActive(true);  
            parent.Hit();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    GameObject gun ;

    public GameObject bullet ;
    public float bulletSpeed = 1000.0f;


    public ForceMode forceMode;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun"); 
      //  bullet = Resources.Load<GameObject>("Art/Props/Prefabs/Bullet");
    }

    // Update is called once per frame
    void Update()
    {


        //on mouse click, instantiate bullet and add force to it
        if(Input.GetMouseButtonDown(0)){
            GameObject bulletShot = Instantiate(bullet, transform.position+new Vector3(0.0f,2.0f,2.0f), transform.rotation);


            //push the bullet forward
            bulletShot.GetComponent<Rigidbody>().AddForce(
                (this.transform.forward+new Vector3(0,1.0f,0.0f)) * bulletSpeed, 
                forceMode
                );
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallonMenu : MonoBehaviour {

    public void Start () 
    {
     
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BalloonMenu")
        {
            Destroy(col.gameObject);
        }
    }


    void Update()
    {

    }
}

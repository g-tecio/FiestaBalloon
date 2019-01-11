using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow" || gameObject.name == "Arrow(Clone)")
        {
            Destroy(col.gameObject);
           // playerScript.Dead();
          
        }
    }
}

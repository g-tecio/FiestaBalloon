using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallon : MonoBehaviour {

    public AudioClip explosion;
   

    public void Start () 
    {
     
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Balloon")
        {
           
            AudioSource.PlayClipAtPoint(explosion, new Vector3(5, 1, 2));
            Destroy(col.gameObject);
            GameManager.health -= 1;
           
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balloon" || collision.gameObject.tag == "Arrow")
        {
           // Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 1.0f);
            print("Collision");
            GameManager.health -= 1;
        }
    }

    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public Rigidbody2D rb;
    public int soundNumber;

    public AudioClip Hit1;
    public AudioClip Hit2;
    public AudioClip Hit3;
    int score;

    public float min = 0.2f;
    public float max = 0.2f;
    public float speed = 0.1f;
    public GameObject deadEffect;

    void Start ()
    {
            min = transform.position.x - 0.2f;
            max = transform.position.x + 0.2f;
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
    }

	void Update () 
    {

        if (score == 5)
        {
            speed = 0.1f;
        }

        if (score == 10)
        {
            speed = 0.2f;
        }

        if (score == 15)
        {
            speed = 0.3f;
        }

        if (score == 20)
        {
            speed = 0.41f;
        }

        if (score == 25)
        {
            speed = 0.5f;
        }

        if (score == 30)
        {
            speed = 0.6f;
        }

        if (score == 35)
        {
            speed = 0.7f;
        }

        if (score == 40)
        {
            speed = 0.8f;
        }

        if (score == 45)
        {
            speed = 0.9f;
        }

        if (score == 50)
        {
            speed = 1.0f;
        }

        if (score == 55)
        {
            speed = 1.1f;
        }

        if (score == 60)
        {
            speed = 1.2f;
        }

        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) - max, transform.position.y, transform.position.z);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 1.0f);
        }
    }
    
    void OnMouseDown()
    {

        soundNumber = Random.Range(1, 3);
        switch (soundNumber)
        {
            case 1:
                AudioSource.PlayClipAtPoint(Hit1, new Vector3(5, 1, 2));
                break;
            case 2:
                AudioSource.PlayClipAtPoint(Hit2, new Vector3(5, 1, 2));
                break;
            case 3:
                AudioSource.PlayClipAtPoint(Hit3, new Vector3(5, 1, 2));
                break;
        }
   
        rb.AddForce(transform.up * -28222);
        GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore();
    }
   



}

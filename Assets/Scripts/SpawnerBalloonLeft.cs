using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalloonLeft : MonoBehaviour {

    public AudioClip inflate;
    public GameObject balloon;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate =2f;
    float nextSpawn = 0.0f;
    int  score;
  
    void Start () 
    {
       
    }

    void Update () 
    {

      score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
        if (GameObject.Find("balloonGreen(Clone)") == null && score > 1 && score % 5 == 0  )
        {
      
            this.gameObject.SetActive(true);
                timer(); 
        }

    }

    void timer()
    {
        if(Time.time>nextSpawn)
        {
            AudioSource.PlayClipAtPoint(inflate, new Vector3(5, 1, 2));
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.0f, -2.0f);
            whereToSpawn = new Vector2 (randX, transform.position.y);
            Instantiate(balloon,whereToSpawn,Quaternion.identity);
        }
    }
}

    


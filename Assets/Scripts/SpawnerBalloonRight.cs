using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalloonRight : MonoBehaviour
{
    public AudioClip inflate;

    public GameObject balloon;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int score;

    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
      //  print("SCORE GREEN: " + score);
        if (GameObject.Find("balloonOrange(Clone)") == null && score > 1 && score % 15 == 0)
        {
   
            //  print("se activó el naranja");
            this.gameObject.SetActive(true);
            timer();


        }
        //else if(GameObject.Find("balloonGreen(Clone)")!=null ){
        //     this.gameObject.SetActive(false);
        //     print("desactivar verde");
        // }

    }
    void timer()
    {
        if (Time.time > nextSpawn)
        {
            AudioSource.PlayClipAtPoint(inflate, new Vector3(5, 1, 2));
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(2.0f, 2.0f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(balloon, whereToSpawn, Quaternion.identity);


        }
    }
}


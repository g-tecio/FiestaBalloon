using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalloonCenter : MonoBehaviour
{
    public AudioClip inflate;
    public GameObject balloon;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    // int  score;

    void Start()
    {
        this.gameObject.SetActive(true);
    }

    void Update()
    {
        //  score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
        if (GameObject.Find("balloonBlue(Clone)") == null)
        {
            this.gameObject.SetActive(true);
            timer();
        }
    }

    void timer()
    {
        if (Time.time > nextSpawn)
        {
            AudioSource.PlayClipAtPoint(inflate, new Vector3(5, 1, 2));
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(0.0f, 0.0f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(balloon, whereToSpawn, Quaternion.identity);
        }
    }
}


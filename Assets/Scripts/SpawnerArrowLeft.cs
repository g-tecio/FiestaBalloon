using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerArrowLeft : MonoBehaviour {

    public AudioClip ArrowSound;
    public GameObject arrow;
    public GameObject warningSign;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int whatToSpawn;
    Vector2 whereToSpawnW;
    int score;

    void Start()
    {

    }

    void Update()
    {

        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
        if (GameObject.Find("ArrowLeft(Clone)") == null && score >= 45)
        {
            AudioSource.PlayClipAtPoint(ArrowSound, new Vector3(5, 1, 2));
            this.gameObject.SetActive(true);
            timer();
        }
   

    }

    void timer()
    {
        if (Time.time > nextSpawn)
        {

            randY = Random.Range(4.0f, -4.5f);
            whereToSpawn = new Vector2(transform.position.x, randY);
            whereToSpawnW = new Vector2(transform.position.x + 5.8f, randY);

            whatToSpawn = Random.Range(1, 2);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(arrow, whereToSpawn, Quaternion.identity);
                    whereToSpawn = new Vector2(transform.position.y, randY);


                    Instantiate(warningSign, whereToSpawnW, Quaternion.identity);
                    whereToSpawnW = new Vector2(transform.position.y, randY);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}

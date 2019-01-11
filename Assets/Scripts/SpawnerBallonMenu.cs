using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBallonMenu : MonoBehaviour {

    public GameObject balloonGreen, balloonOrange, balloonPink, balloonYellow, balloonBlue, balloonPurple;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int whatToSpawn;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {

            randX = Random.Range(-2.85f, 2.85f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            //   Instantiate(balloon, whereToSpawn, Quaternion.identity);

            whatToSpawn = Random.Range(1, 6);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(balloonGreen, whereToSpawn, Quaternion.identity);
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    break;
                case 2:
                    Instantiate(balloonOrange, whereToSpawn, Quaternion.identity);
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    break;
                case 3:
                    Instantiate(balloonPink, whereToSpawn, Quaternion.identity);
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    break;
                case 4:
                    Instantiate(balloonYellow, whereToSpawn, Quaternion.identity);
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    break;
                case 5:
                    Instantiate(balloonBlue, whereToSpawn, Quaternion.identity);
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    break;
                case 6:
                    Instantiate(balloonPurple, whereToSpawn, Quaternion.identity);
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    break;

            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}

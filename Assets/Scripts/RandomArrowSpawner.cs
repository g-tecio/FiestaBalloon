using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArrowSpawner : MonoBehaviour {

    public GameObject arrowRightSpawner;
    public GameObject arrowLeftSpawner;

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
      //  print("TIEMPO: " + Time.time);
        timer();

    }

    void timer()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 3);
         //   print("RANDOM NUMBER " + whatToSpawn);
            switch (whatToSpawn)
            {
                case 1:
                    arrowRightSpawner.gameObject.SetActive(true);
                    arrowLeftSpawner.gameObject.SetActive(false);
            //        print("RIGHT");
                    break;

                case 2:
                    arrowLeftSpawner.gameObject.SetActive(true);
                    arrowRightSpawner.gameObject.SetActive(false);
              //      print("LEFT");
                    break;
            }
            nextSpawn = Time.time + spawnRate;
           // print("TIEMPO: " + Time.time);
        }
    }
}
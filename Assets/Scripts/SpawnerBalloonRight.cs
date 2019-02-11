﻿using System.Collections;
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
    int whatToSpawn;
    bool skinNeon;
    public Sprite balloonNeonCenterSprite;


    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        skinNeon = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNeon;
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
      //  print("SCORE GREEN: " + score);
        if (GameObject.Find("balloonOrange(Clone)") == null && score > 1 && score % 15 == 0)
        {
   
            //  print("se activó el naranja");
            this.gameObject.SetActive(true);
            if (skinNeon == true)
            {
                timerForNeon();
            }
            else
            {
                timer();
            }



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

    void timerForNeon()
    {
        if (Time.time > nextSpawn)
        {
            AudioSource.PlayClipAtPoint(inflate, new Vector3(5, 1, 2));
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(2.0f, 2.0f);

            whatToSpawn = Random.Range(1, 6);
            switch (whatToSpawn)
            {
                case 1:
                    balloonNeonCenterSprite = Resources.Load<Sprite>("Neon/BalloonBlueNeon");
                    balloon.GetComponent<SpriteRenderer>().sprite = balloonNeonCenterSprite;
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    Instantiate(balloon, whereToSpawn, Quaternion.identity);
                    break;
                case 2:
                    balloonNeonCenterSprite = Resources.Load<Sprite>("Neon/BalloonRedNeon");
                    balloon.GetComponent<SpriteRenderer>().sprite = balloonNeonCenterSprite;
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    Instantiate(balloon, whereToSpawn, Quaternion.identity);
                    break;
                case 3:
                    balloonNeonCenterSprite = Resources.Load<Sprite>("Neon/BalloonGreenNeon");
                    balloon.GetComponent<SpriteRenderer>().sprite = balloonNeonCenterSprite;
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    Instantiate(balloon, whereToSpawn, Quaternion.identity);
                    break;
                case 4:
                    balloonNeonCenterSprite = Resources.Load<Sprite>("Neon/BalloonYellowNeon");
                    balloon.GetComponent<SpriteRenderer>().sprite = balloonNeonCenterSprite;
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    Instantiate(balloon, whereToSpawn, Quaternion.identity);
                    break;
                case 5:
                    balloonNeonCenterSprite = Resources.Load<Sprite>("Neon/BalloonWhiteNeon");
                    balloon.GetComponent<SpriteRenderer>().sprite = balloonNeonCenterSprite;
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    Instantiate(balloon, whereToSpawn, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}


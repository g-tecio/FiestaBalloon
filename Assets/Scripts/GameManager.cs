using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverPanel, missionsPanel, mainMenuPanel, panelGameScene, showTutorial, heart1, heart2, heart3, closeTutorialButton, showComingSoon, toggleButton, showComingSoonEnd, balloonMenu;
    public GameObject ballonSpawnerCenter, ballonSpawnerLeft, ballonSpawnerRight, arrowSpanerRight, arrowSpanerLeft, arrowRight, arrowLeft, balloonCenter, balloonLeft, balloonRight, buttonTapToPlay;
    public static int health;

    public GameObject WhiteBalloonMenu;


    bool toggle;
    public bool gameHasBegun;

    void Start()
    {

        // Application.targetFrameRate = 300;


        if (PlayerPrefs.HasKey("select"))
        {
            if (PlayerPrefs.GetInt("select") == 1)
            {
                toggleButton.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
                AudioListener.volume = 0f;
            }
            else
            {
                toggleButton.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
                AudioListener.volume = 1f;
            }
        }

        mainMenuPanel.gameObject.SetActive(true);
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);



        Time.timeScale = 1;

        arrowSpanerRight.gameObject.SetActive(true);
        arrowSpanerLeft.gameObject.SetActive(true);
        arrowRight.gameObject.SetActive(true);
        arrowLeft.gameObject.SetActive(true);
        balloonCenter.gameObject.SetActive(true);
        balloonLeft.gameObject.SetActive(true);
        balloonRight.gameObject.SetActive(true);

        ballonSpawnerCenter.SetActive(true);
        ballonSpawnerLeft.SetActive(true);
        ballonSpawnerRight.SetActive(true);
    }


    void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (toggleButton.GetComponent<UnityEngine.UI.Toggle>().isOn == true)
        {
            //print("THE SOUND IS MUTED");
            PlayerPrefs.SetInt("select", 1);
            AudioListener.volume = 0f;
        }
        else
        {
            // print("THE SOUND IS TURNED ON");
            PlayerPrefs.SetInt("select", 0);
            AudioListener.volume = 1f;
        }

        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);

                break;
            case 2:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);

                break;
            case 1:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOverPanel.gameObject.SetActive(true);
                GameObject ballons = GameObject.FindWithTag("Balloon");
                Destroy(ballons.gameObject);

                balloonCenter.gameObject.SetActive(false);
                balloonLeft.gameObject.SetActive(false);
                balloonRight.gameObject.SetActive(false);

                GameOver();
                break;
        }


        if (gameOverPanel.gameObject.activeInHierarchy == true)
        {
            // print("ESTA ACTIVADO");
            panelGameScene.gameObject.SetActive(false);
            arrowSpanerRight.gameObject.SetActive(false);
            arrowSpanerLeft.gameObject.SetActive(false);
            arrowRight.gameObject.SetActive(false);
            arrowLeft.gameObject.SetActive(false);
            balloonCenter.gameObject.SetActive(false);
            balloonLeft.gameObject.SetActive(false);
            balloonRight.gameObject.SetActive(false);

            ballonSpawnerCenter.SetActive(false);
            ballonSpawnerLeft.SetActive(false);
            ballonSpawnerRight.SetActive(false);

            //BlackScreen.SetActive(false);


        }
        else
        {
            // print("NEL PERRO");
        }


        if (panelGameScene.gameObject.activeInHierarchy == true)
        {


            //  GameObject balloonMenu = GameObject.FindWithTag("BalloonMenu");
            //  Destroy(balloonMenu.gameObject);
            //  print("Impreso");

        }

    }
    public void GameOver()
    {


        //   StartCoroutine(gameOverCoroutine());

        /*
           GameObject ballons = GameObject.FindWithTag("Balloon");
           Destroy(ballons.gameObject);

           GameObject spawner = GameObject.FindWithTag("Spawner");
           Destroy(spawner.gameObject);

         GameObject arrow = GameObject.FindWithTag("Arrow");
         Destroy(arrow.gameObject);
         */


    }



    IEnumerator gameOverCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.5f);
        yield break;
    }

    public void GameBegin()
    {
        mainMenuPanel.gameObject.SetActive(false);
        panelGameScene.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
        gameHasBegun = true;

    }

    public void ReloadGame()
    {
        gameOverPanel.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("print");
    }

    public void ShowTutorial()
    {
        showTutorial.gameObject.SetActive(true);
        closeTutorialButton.gameObject.SetActive(true);
        buttonTapToPlay.gameObject.SetActive(false);
    }

    public void CloseTutorial()
    {
        showTutorial.gameObject.SetActive(false);
        closeTutorialButton.gameObject.SetActive(false);
        buttonTapToPlay.gameObject.SetActive(true);
    }

    public void ShowComingSoon()
    {
        StartCoroutine(RemoveAfterSeconds(1, showComingSoon));
        showComingSoon.gameObject.SetActive(true);
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

    public void ShowComingSoonEnd()
    {
        StartCoroutine(RemoveAfterSeconds(1, showComingSoonEnd));
        showComingSoonEnd.gameObject.SetActive(true);

    }

    public void ShowMissions()
    {
        missionsPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);

    }

    public void CloseMissions()
    {
        missionsPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);

    }





}

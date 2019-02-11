using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;
#if UNITY_IOS
using UnityEngine.SocialPlatforms.GameCenter;
#endif

public class GameManager : MonoBehaviour
{

    public GameObject gameOverPanel, missionsPanel, mainMenuPanel, panelGameScene, panelStore, showTutorial, heart1, heart2, heart3, closeTutorialButton, showComingSoon, toggleButton, showComingSoonEnd, loveWord;
    public GameObject ballonSpawnerCenter, ballonSpawnerLeft, ballonSpawnerRight, arrowSpanerRight, arrowSpanerLeft, arrowRight, arrowLeft, balloonCenter, balloonLeft, balloonRight, buttonTapToPlay;

    public GameObject buttonStore, buttonNoAds, buttonSound, buttonLeaderboard, panelHasBeenBought, buttonRestorePurchase;
    public static int health;
    int NumGame;
    public bool Adfree, loginSuccessful;

    public GameObject WhiteBalloonMenu;

    public string ANDROID_RATE_URL = "market://details?id=com.games.cartwheelgalaxy.fiestaballoon";

    public string IOS_RATE_URL = "itms-apps://itunes.apple.com/app/1450320376";
    public long score;
    public LeaderboardManager script;

    bool toggle, SkinValentine;
    string mensaje;
    public bool gameHasBegun;
    System.Action<bool> callback;
    void Start()

          
    {

        //Application.targetFrameRate = 300;
        //QualitySettings.vSyncCount = 1; 

#if UNITY_IOS
        SignIn(callback);
#endif

        // Application.targetFrameRate = 300;
        NumGame = PlayerPrefs.GetInt("NumGame");

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
        SkinValentine = GameObject.Find("SkinManager").GetComponent<SkinManager>().SkinValentine;
        print("SKIN NORMAL EN GAMESCENE " + SkinValentine);

        Adfree = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().Adfree;
        //print("ADFREE UPDATE " + Adfree);

        // PurchaseTest noAds = gameObject.GetComponent<PurchaseTest>();
        if (Adfree)
        {
            AdMob.bannerView.Destroy();
        }

        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
        Debug.Log("SCORE DE GAME MANAGER " + score);

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
                panelGameScene.gameObject.SetActive(false);

                GameObject ballons = GameObject.FindWithTag("Balloon");
                Destroy(ballons.gameObject);

                GameObject arrows = GameObject.FindWithTag("Arrow");
                Destroy(arrows.gameObject);

                //AudioListener.volume = 1f;
                balloonCenter.gameObject.SetActive(false);
                balloonLeft.gameObject.SetActive(false);
                balloonRight.gameObject.SetActive(false);
                GameOver();


                break;
        }


        if (gameOverPanel.gameObject.activeInHierarchy == true)
        {
            // print("ESTA ACTIVADO");
            //AdMob.RequestBanner();
            panelGameScene.gameObject.SetActive(false);
           // wordLove.gameObject.SetActive(false);
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

            if(Adfree == true)
            {
                AdMob.bannerView.Destroy();
            }
            
            //BlackScreen.SetActive(false);


        }
        else
        {
            // print("NEL PERRO");
        }


        if (panelGameScene.gameObject.activeInHierarchy == true)
        {
            AdMob.bannerView.Destroy();
            //AdMob.bannerView.Hide();

            if (SkinValentine == true)
            {
                loveWord.gameObject.SetActive(true);
            }
            else
            {
                loveWord.gameObject.SetActive(false);
            }
            
        }
   

    }
    public void GameOver()
    {


#if UNITY_ANDROID
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            // Note: make sure to add 'using GooglePlayGames'
            PlayGamesPlatform.Instance.ReportScore(score,
                GPGSIds.leaderboard_top_players,
                (bool success) =>
                {
                    Debug.Log("(Lollygagger) Leaderboard update success: " + success);
                    Debug.Log("Score mandado " + score);
                });
        }
#endif

#if UNITY_IOS
   PostScoreOnLeaderBoard(score);
#endif

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
       // AdMob.bannerView.Hide();
        mainMenuPanel.gameObject.SetActive(false);
        panelGameScene.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
        gameHasBegun = true;

    }

    public void ReloadGame()
    {
        NumGame = NumGame + 1;
        gameOverPanel.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // Debug.Log("print");

       // print("Numero de partida:" + NumGame);

        PlayerPrefs.SetInt("NumGame", NumGame);

        if (NumGame % 3 == 0 && Adfree == false)
        {
            Advertisement.Show();

        }


    }

    public void ShowTutorial()
    {
        showTutorial.gameObject.SetActive(true);
        closeTutorialButton.gameObject.SetActive(true);


        buttonTapToPlay.gameObject.SetActive(false);

        buttonStore.gameObject.SetActive(false);
        buttonNoAds.gameObject.SetActive(false);
        buttonSound.gameObject.SetActive(false);
        buttonLeaderboard.gameObject.SetActive(false);

#if UNITY_ANDROID
        buttonRestorePurchase.gameObject.SetActive(false);
#elif UNITY_IPHONE
 buttonRestorePurchase.gameObject.SetActive(true);
#endif


    }

    public void CloseTutorial()
    {
        showTutorial.gameObject.SetActive(false);
        closeTutorialButton.gameObject.SetActive(false);
        buttonTapToPlay.gameObject.SetActive(true);

        buttonStore.gameObject.SetActive(true);
        buttonNoAds.gameObject.SetActive(true);
        buttonSound.gameObject.SetActive(true);
        buttonLeaderboard.gameObject.SetActive(true);



#if UNITY_ANDROID
        buttonRestorePurchase.gameObject.SetActive(false);
#elif UNITY_IPHONE
 buttonRestorePurchase.gameObject.SetActive(false);
#endif

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

    public void ShowStore()
    {
        panelStore.gameObject.SetActive(true);
        mainMenuPanel.gameObject.SetActive(false);

    }

    public void CloseStore()
    {
        panelStore.gameObject.SetActive(false);
        mainMenuPanel.gameObject.SetActive(true);

    }

    public void CloseHasBeenBought()
    {
        panelHasBeenBought.gameObject.SetActive(false);
    }



    public void RateApp()
    {
#if UNITY_ANDROID
        Application.OpenURL(ANDROID_RATE_URL);
#elif UNITY_IPHONE
        Application.OpenURL(IOS_RATE_URL);
#endif
    }

    public void SignInCallback(bool success)
    {

        if (success)
        {
            Debug.Log("(Lollygagger) Signed in!");

            // Change sign-in button text
            print("Sign out");

            // Show the user's name
            print("Signed in as: " + Social.localUser.userName);
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");
#if UNITY_ANDROID
            LoginAndroid();
#endif
#if UNITY_IPHONE

#endif
            // Show failure message
            print("Sign in");
            print("Sign-in failed");
        }

    }
    public void LoginAndroid()
    {
#if UNITY_ANDROID
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            print("Sign In");

        }
#endif

    }
    void ReportScore(long score, string leaderboardID)
    {
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success =>
        {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    public static bool IsGCUseLoggedIn
    {
        get
        {
            Debug.Log("LOGGEDIN " + Social.localUser.authenticated);
            return Social.localUser.authenticated;

        }
    }
    public static string GCUsername
    {
        get
        {
            return Social.Active.localUser.userName;
        }
    }
    public static void SignIn(System.Action<bool> callback)
    {
        Social.localUser.Authenticate(callback);
        Debug.Log("CALLBACK " + callback);
    }


    public static void UpdateLeaderboard(string id, long score)
    {
        if (IsGCUseLoggedIn)
        {
            Social.ReportScore(score, id, null);
        }

    }


    public void PostScoreOnLeaderBoard(long myScore)

    {


        if (loginSuccessful)

        {

            Debug.Log("si entro al login");

            Social.ReportScore(score, "55969983", (bool success) => {

                if (success)

                    Debug.Log("Successfully uploaded");


                // handle success or failure

            });

        }

        else

        {

            Social.localUser.Authenticate((bool success) => {

                if (success)

                {

                    loginSuccessful = true;

                    Debug.Log("Si se arma");

                    Social.ReportScore(myScore, "55969983", (bool successful) => {

                        // handle success or failure

                        Debug.Log("Si se arma2");
                    });

                }

                else

                {

                    Debug.Log("unsuccessful");

                }

                // handle success or failure

            });

        }

    }
}








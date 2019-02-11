using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour {


    public GameObject arrowRight, arrowLeft, balloonCenter, balloonLeft, balloonRight, balloonMenu, warningSign, lockIcon, heartGroup, gameTitleM, gameTitleS;
    public GameObject lockIconValentine, lockIconNeon, lifeHeart1, lifeHeart2, lifeHeart3;

    public Sprite balloonHeartSprite, arrowHeartRightSprite, arrowHeartLeftSprite, warningSignRed;
    public Sprite balloonWhiteSprite, arrowWhiteRightSprite, arrowWhiteLeftSprite, warningSignWhite;
    public Sprite balloonNeonSprite, balloonNeonCenterSprite, balloonNeonLeftSprite, balloonNeonRightSprite, arrowNeonRightSprite, arrowNeonLeftSprite, warningSignNeon, gameTitleMenu, gameTitleStore, LifeNeon;


    public Image UIBackground;
    int randomBackground;
    bool gamehasBegun;

    public bool SkinValentine, SkinNormal, skinNeon;

    public bool SkinOwnedValentine, SkinOwnedNormal, skinOwnedNeon;


    private int actualCurrency = 0;

    int priceValentine = 10;
    int priceNeon = 0;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        SkinValentine = Convert.ToBoolean(PlayerPrefs.GetInt("SkinValentine"));
        SkinNormal = Convert.ToBoolean(PlayerPrefs.GetInt("SkinNormal"));
        SkinOwnedValentine = Convert.ToBoolean(PlayerPrefs.GetInt("SkinOwnedValentine"));
        priceValentine = PlayerPrefs.GetInt("priceValentine");

        skinNeon = Convert.ToBoolean(PlayerPrefs.GetInt("skinNeon"));
        skinOwnedNeon = Convert.ToBoolean(PlayerPrefs.GetInt("skinOwnedNeon"));
        priceNeon = PlayerPrefs.GetInt("priceNeon");

        if (SkinNormal == false && SkinValentine == false)
        {
            ChangeBackground1();
        }

        if (SkinNormal == true)
        {
            ChangeBackground1();
        }

        if (SkinValentine == true)
        {
            ChangeBackground2();
        }

        if (skinNeon == true)
        {
            ChangeBackground3();
        }



        if (SkinOwnedValentine == true)
        {
            lockIcon.gameObject.gameObject.SetActive(false);
            priceValentine = 0;
        }
        else
        {
            priceValentine = 100;
        }


        if (skinOwnedNeon == true)
        {
            lockIconNeon.gameObject.gameObject.SetActive(false);
            priceNeon = 0;
        }
        else
        {
            priceNeon = 0;
        }


        if (SkinNormal == true)
        {
            //NORMAL SKIN
            balloonWhiteSprite = Resources.Load<Sprite>("Normal/BalloonWhite");
            balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;
            balloonCenter.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;
            balloonLeft.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;
            balloonRight.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;

            arrowWhiteRightSprite = Resources.Load<Sprite>("Normal/ArrowRight");
            arrowRight.GetComponent<SpriteRenderer>().sprite = arrowWhiteRightSprite;

            arrowWhiteLeftSprite = Resources.Load<Sprite>("Normal/ArrowLeft");
            arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowWhiteLeftSprite;

            warningSignWhite = Resources.Load<Sprite>("Normal/WarningBlack");
            warningSign.GetComponent<SpriteRenderer>().sprite = warningSignWhite;

            heartGroup.gameObject.SetActive(false);
          //  wordLove.gameObject.SetActive(false);
        }

        if (SkinValentine == true)
        {
            //VALENTINE'S SKIN
            balloonHeartSprite = Resources.Load<Sprite>("Valentine/BalloonHeart");
            balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;
            balloonCenter.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;
            balloonLeft.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;
            balloonRight.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;

            arrowHeartRightSprite = Resources.Load<Sprite>("Valentine/ArrowHeartRight");
            arrowRight.GetComponent<SpriteRenderer>().sprite = arrowHeartRightSprite;

            arrowHeartLeftSprite = Resources.Load<Sprite>("Valentine/ArrowHeartLeft");
            arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowHeartLeftSprite;

            warningSignRed = Resources.Load<Sprite>("Valentine/WarningSignRed");
            warningSign.GetComponent<SpriteRenderer>().sprite = warningSignRed;

            heartGroup.gameObject.SetActive(true);
         //   wordLove.gameObject.SetActive(false);
        }


        if (skinNeon == true)
        {
            //NEON SKIN
            balloonNeonSprite = Resources.Load<Sprite>("Neon/balloonNeonSprite");
            balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;

            balloonNeonCenterSprite = Resources.Load<Sprite>("Neon/BalloonBlueNeon");
            balloonCenter.GetComponent<SpriteRenderer>().sprite = balloonNeonCenterSprite;

            balloonNeonLeftSprite = Resources.Load<Sprite>("Neon/BalloonGreenNeon");
            balloonLeft.GetComponent<SpriteRenderer>().sprite = balloonNeonLeftSprite;

            balloonNeonRightSprite = Resources.Load<Sprite>("Neon/BalloonRedNeon");
            balloonRight.GetComponent<SpriteRenderer>().sprite = balloonNeonRightSprite;

            arrowNeonRightSprite = Resources.Load<Sprite>("Neon/ArrowNeonRight");
            arrowRight.GetComponent<SpriteRenderer>().sprite = arrowNeonRightSprite;

            arrowNeonLeftSprite = Resources.Load<Sprite>("Neon/ArrowNeonLeft");
            arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowNeonLeftSprite;

            warningSignNeon = Resources.Load<Sprite>("Neon/WarningNeonSign");
            warningSign.GetComponent<SpriteRenderer>().sprite = warningSignNeon;

            gameTitleMenu = Resources.Load<Sprite>("Neon/GameTitleNeon");
            gameTitleM.GetComponent<SpriteRenderer>().sprite = gameTitleMenu;

            gameTitleMenu = Resources.Load<Sprite>("Neon/GameTitleNeon");
            gameTitleS.GetComponent<SpriteRenderer>().sprite = gameTitleMenu;

            LifeNeon = Resources.Load<Sprite>("Neon/LifeNeon");
            lifeHeart1.GetComponent<SpriteRenderer>().sprite = LifeNeon;
            lifeHeart2.GetComponent<SpriteRenderer>().sprite = LifeNeon;
            lifeHeart3.GetComponent<SpriteRenderer>().sprite = LifeNeon;



        }



    }


    public void SkinNormalSelected()
    {
        SkinNormal = true;
        SkinValentine = false;
        skinNeon = false;
        PlayerPrefs.SetInt("SkinValentine", Convert.ToInt32(SkinValentine));
        PlayerPrefs.SetInt("SkinNormal", Convert.ToInt32(SkinNormal));
        PlayerPrefs.SetInt("skinNeon", Convert.ToInt32(skinNeon));

        heartGroup.gameObject.SetActive(false);
      //  wordLove.gameObject.SetActive(false);


        //NORMAL SKIN
        balloonWhiteSprite = Resources.Load<Sprite>("Normal/BalloonWhite");
        balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;
        balloonCenter.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;
        balloonLeft.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;
        balloonRight.GetComponent<SpriteRenderer>().sprite = balloonWhiteSprite;

        arrowWhiteRightSprite = Resources.Load<Sprite>("Normal/ArrowRight");
        arrowRight.GetComponent<SpriteRenderer>().sprite = arrowWhiteRightSprite;

        arrowWhiteLeftSprite = Resources.Load<Sprite>("Normal/ArrowLeft");
        arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowWhiteLeftSprite;

        warningSignWhite = Resources.Load<Sprite>("Normal/WarningBlack");
        warningSign.GetComponent<SpriteRenderer>().sprite = warningSignWhite;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


    public void SkinValentineSelected()
    {
       // actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;

        if (actualCurrency >= priceValentine)
        {

            actualCurrency = actualCurrency - priceValentine;
            priceValentine = 0;

            PlayerPrefs.SetInt("priceValentine", priceValentine);
     
            PlayerPrefs.SetInt("Currency", actualCurrency);

           // print("CURRENCY AFTER YOU HAVE BOUGHT A SKIN:" + actualCurrency);

            lockIcon.gameObject.SetActive(false);

            SkinValentine = true;
            SkinNormal = false;
            skinNeon = false;
            PlayerPrefs.SetInt("SkinValentine", Convert.ToInt32(SkinValentine));
            PlayerPrefs.SetInt("SkinNormal", Convert.ToInt32(SkinNormal));
            PlayerPrefs.SetInt("skinNeon", Convert.ToInt32(skinNeon));

            SkinOwnedValentine = true;
            PlayerPrefs.SetInt("SkinOwnedValentine", Convert.ToInt32(SkinOwnedValentine));

            heartGroup.gameObject.SetActive(true);
          //  wordLove.gameObject.SetActive(false);

            //VALENTINE'S SKIN
            balloonHeartSprite = Resources.Load<Sprite>("Valentine/BalloonHeart");
            balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;
            balloonCenter.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;
            balloonLeft.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;
            balloonRight.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;

            arrowHeartRightSprite = Resources.Load<Sprite>("Valentine/ArrowHeartRight");
            arrowRight.GetComponent<SpriteRenderer>().sprite = arrowHeartRightSprite;

            arrowHeartLeftSprite = Resources.Load<Sprite>("Valentine/ArrowHeartLeft");
            arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowHeartLeftSprite;

            warningSignRed = Resources.Load<Sprite>("Valentine/WarningSignRed");
            warningSign.GetComponent<SpriteRenderer>().sprite = warningSignRed;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
         //   print("You don't have enough currency");
        }

    }


    public void SkinNeonSelected()
    {
        // actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;

        if (actualCurrency >= priceNeon)
        {

            actualCurrency = actualCurrency - priceNeon;
            priceNeon = 0;

            PlayerPrefs.SetInt("priceNeon", priceNeon);
            PlayerPrefs.SetInt("Currency", actualCurrency);

            // print("CURRENCY AFTER YOU HAVE BOUGHT A SKIN:" + actualCurrency);

            lockIconNeon.gameObject.SetActive(false);

            SkinValentine = false;
            SkinNormal = false;
            skinNeon = true;
            PlayerPrefs.SetInt("SkinValentine", Convert.ToInt32(SkinValentine));
            PlayerPrefs.SetInt("SkinNormal", Convert.ToInt32(SkinNormal));
            PlayerPrefs.SetInt("skinNeon", Convert.ToInt32(skinNeon));

            skinOwnedNeon = true;
            PlayerPrefs.SetInt("skinOwnedNeon", Convert.ToInt32(skinOwnedNeon));

            //NEON SKIN
            balloonNeonSprite = Resources.Load<Sprite>("Neon/balloonNeonSprite");
            balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonHeartSprite;

            balloonNeonCenterSprite = Resources.Load<Sprite>("Neon/BalloonBlueNeon");
            balloonCenter.GetComponent<SpriteRenderer>().sprite = balloonNeonCenterSprite;

            balloonNeonLeftSprite = Resources.Load<Sprite>("Neon/BalloonGreenNeon");
            balloonLeft.GetComponent<SpriteRenderer>().sprite = balloonNeonLeftSprite;

            balloonNeonRightSprite = Resources.Load<Sprite>("Neon/BalloonRedNeon");
            balloonRight.GetComponent<SpriteRenderer>().sprite = balloonNeonRightSprite;

            arrowNeonRightSprite = Resources.Load<Sprite>("Neon/ArrowNeonRight");
            arrowRight.GetComponent<SpriteRenderer>().sprite = arrowNeonRightSprite;

            arrowNeonLeftSprite = Resources.Load<Sprite>("Neon/ArrowNeonLeft");
            arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowNeonLeftSprite;

            warningSignNeon = Resources.Load<Sprite>("Neon/WarningNeonSign");
            warningSign.GetComponent<SpriteRenderer>().sprite = warningSignNeon;

            gameTitleMenu = Resources.Load<Sprite>("Neon/GameTitleNeon");
            gameTitleM.GetComponent<SpriteRenderer>().sprite = gameTitleMenu;

            gameTitleMenu = Resources.Load<Sprite>("Neon/GameTitleNeon");
            gameTitleS.GetComponent<SpriteRenderer>().sprite = gameTitleMenu;

            LifeNeon = Resources.Load<Sprite>("Neon/LifeNeon");
            lifeHeart1.GetComponent<SpriteRenderer>().sprite = LifeNeon;
            lifeHeart2.GetComponent<SpriteRenderer>().sprite = LifeNeon;
            lifeHeart3.GetComponent<SpriteRenderer>().sprite = LifeNeon;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            //   print("You don't have enough currency");
        }

    }



    void Update()
    {
        actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;
        print("CURRENCY AT THE START " + actualCurrency);
        gamehasBegun = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasBegun;
        if (gamehasBegun == true)
        {
       //     wordLove.gameObject.SetActive(true);

        }
        else
        {
        //    wordLove.gameObject.SetActive(false);
        }
        
        }


    void ChangeBackground1()
    {
        UIBackground = GameObject.Find("PanelImageBackground").GetComponent<Image>();
        randomBackground = UnityEngine.Random.Range(1, 8);
      //  print("RANDOM NORMAL: " + randomBackground);
        switch (randomBackground)
        {
            case 1:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient1");
                break;
            case 2:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient2");
                break;
            case 3:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient3");
                break;
            case 4:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient4");
                break;
            case 5:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient5");
                break;
            case 6:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient6");
                break;
            case 7:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient7");
                break;
        }
    }

    void ChangeBackground2()
    {
        UIBackground = GameObject.Find("PanelImageBackground").GetComponent<Image>();
        randomBackground = UnityEngine.Random.Range(1, 4);
      //  print("RANDOM VALENTINE: " + randomBackground);
        switch (randomBackground)
        {
            case 1:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient6");
                break;
            case 2:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient8");
                break;
            case 3:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient9");
                break;

        }
    }

    void ChangeBackground3()
    {
        UIBackground = GameObject.Find("PanelImageBackground").GetComponent<Image>();
        UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient10");
  
    }


}

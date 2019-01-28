using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour {


    public GameObject arrowRight, arrowLeft, balloonCenter, balloonLeft, balloonRight, balloonMenu, warningSign, lockIcon, heartGroup;
    public Sprite balloonHeartSprite, arrowHeartRightSprite, arrowHeartLeftSprite, warningSignRed;
    public Sprite balloonWhiteSprite, arrowWhiteRightSprite, arrowWhiteLeftSprite, warningSignWhite;
    public Image UIBackground;
    int randomBackground;
    bool gamehasBegun;

    public bool SkinValentine, SkinNormal;

    public bool SkinOwnedValentine, SkinOwnedNormal;

    
    private int actualCurrency = 0;

    int priceValentine = 10;

    void Start ()
    {
        //PlayerPrefs.DeleteAll();
        SkinValentine = Convert.ToBoolean(PlayerPrefs.GetInt("SkinValentine"));
        SkinNormal = Convert.ToBoolean(PlayerPrefs.GetInt("SkinNormal"));
        SkinOwnedValentine = Convert.ToBoolean(PlayerPrefs.GetInt("SkinOwnedValentine"));
        priceValentine = PlayerPrefs.GetInt("priceValentine");

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
      


        if (SkinOwnedValentine == true)
        {
            lockIcon.gameObject.gameObject.SetActive(false);
            priceValentine = 0;
        }
        else
        {
            priceValentine = 100;
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
    }


    public void SkinNormalSelected()
    {
        SkinNormal = true;
        SkinValentine = false;
        PlayerPrefs.SetInt("SkinValentine", Convert.ToInt32(SkinValentine));
        PlayerPrefs.SetInt("SkinNormal", Convert.ToInt32(SkinNormal));


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
            PlayerPrefs.SetInt("SkinValentine", Convert.ToInt32(SkinValentine));
            PlayerPrefs.SetInt("SkinNormal", Convert.ToInt32(SkinNormal));

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

    void Update()
    {
        actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;

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


}

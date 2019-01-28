using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValentineSkin : MonoBehaviour
{
    public Sprite balloonHeart;
  //  public Sprite ArrowHeartLeft;
  //  public Sprite ArrowHeartRight;

    public Sprite balloonWhite;
  //  public Sprite ArrowLeft;
   // public Sprite ArrowRight;

    public GameObject lockIcon;

    public bool SkinValentine, SkinNormal;

    private int actualCurrency = 0;


    void Start()
    {
        SkinValentine = Convert.ToBoolean(PlayerPrefs.GetInt("SkinValentine"));

        this.gameObject.GetComponent<SpriteRenderer>().sprite = balloonHeart;

        //this.gameObject.GetComponent<SpriteRenderer>().sprite = ArrowHeartLeft;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = ArrowHeartRight;

    }

    void Update()
    {
        actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;
    }


    void SkinNormalSelected()
    {
        SkinNormal = true;
        SkinValentine = false;
        PlayerPrefs.SetInt("SkinValentine", Convert.ToInt32(SkinValentine));
    }


    void SkinValentineSelected()
    {
        if (actualCurrency >= 10)
        {
            actualCurrency = actualCurrency - 10;
            lockIcon.gameObject.gameObject.SetActive(false);

            SkinValentine = true;
            PlayerPrefs.SetInt("SkinValentine", Convert.ToInt32(SkinValentine));



        }

    }



}

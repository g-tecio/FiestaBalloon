using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public float fadeOutTime = 0.5f;
    bool gamehasBegunFade;
    int whatToSpawn;
    bool skinNeon;
    float nextSpawn = 0.0f;
    public float spawnRate = 5f;

    public Sprite balloonNeonSprite;
    public GameObject balloonMenu;

    //public Sprite balloonNeonCenterSprite, balloonNeonLeftSprite, balloonNeonRightSprite, arrowNeonRightSprite, arrowNeonLeftSprite, warningSignNeon, gameTitleMenu, gameTitleStore;


    void Start()
    {
    
       
        
    }

    void Update()
    {
        gamehasBegunFade = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasBegun;
        //print("FADE BALLOONS" + gamehasBegunFade);

        if (gamehasBegunFade == true)
        {
            StartCoroutine(SpriteFadeOut(GetComponent<SpriteRenderer>()));
        }
        else
        {
            //NOTHING WILL HAPPEN
        }


        skinNeon = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNeon;
        print("MENU DEL FADE OUT" + skinNeon);

        if (skinNeon == true)
        {
            if (Time.time > nextSpawn)
            {

                whatToSpawn = Random.Range(1, 6);
            switch (whatToSpawn)
            {
                //NEON SKIN
                case 1:
                    balloonNeonSprite = Resources.Load<Sprite>("Neon/BalloonBlueNeon");
                    balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonNeonSprite;
                    break;
                case 2:
                    balloonNeonSprite = Resources.Load<Sprite>("Neon/BalloonRedNeon");
                    balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonNeonSprite;
                    break;
                case 3:
                    balloonNeonSprite = Resources.Load<Sprite>("Neon/BalloonGreenNeon");
                    balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonNeonSprite;
                    break;
                case 4:
                    balloonNeonSprite = Resources.Load<Sprite>("Neon/BalloonYellowNeon");
                    balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonNeonSprite;
                    break;
                case 5:
                    balloonNeonSprite = Resources.Load<Sprite>("Neon/BalloonWhiteNeon");
                    balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonNeonSprite;
                    break;
                case 6:
                    balloonNeonSprite = Resources.Load<Sprite>("Neon/BalloonBlueNeon");
                    balloonMenu.GetComponent<SpriteRenderer>().sprite = balloonNeonSprite;
                    break;
            }
                nextSpawn = Time.time + spawnRate;
            }
        }
    }

    IEnumerator SpriteFadeOut ( SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;

        while (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTime;
            _sprite.color = tmpColor;

            if (tmpColor.a <= 0f)
                tmpColor.a = 0.0f;

            yield return null;
        }
        _sprite.color = tmpColor;
    }
}
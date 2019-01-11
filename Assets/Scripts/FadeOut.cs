using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public float fadeOutTime = 0.5f;
    bool gamehasBegunFade;

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
        }else
        {
           //NOTHING WILL HAPPEN
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
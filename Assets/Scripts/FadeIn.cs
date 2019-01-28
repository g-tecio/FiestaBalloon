using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    bool gamehasBegunFade;

    SpriteRenderer rend;

    public void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

    }

    public void Update()
    {
        gamehasBegunFade = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasBegun;
        //print("FADE BALLOONS" + gamehasBegunFade);
    

    }

    IEnumerator FadeInSprite()
    {
        for(float f = 0.5f; f<=1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = 0f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);

        }
    }

    public void StartFading()
    {
        if (gamehasBegunFade == true)
        {
            StartCoroutine("FadeInSprite");
        }
        else
        {
            //NOTHING WILL HAPPEN
        }
    }
}
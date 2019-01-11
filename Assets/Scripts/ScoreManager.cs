using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour {

	public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI YourScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI best;
    int randomBackground;
    public Image UIBackground;

    public int currentScore = 0;

    public Missions Script;
    //bool claimR1;

    public int scoreAcumlated, scoreStored, scoreAcumlated2, scoreStored2;

    //currentcy
    public int saveCurrency;
    public int currency;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI currencyPlus;
    public GameObject currencyBonus;
    private bool premium = false;


    void Start () 
    {

        scoreStored = PlayerPrefs.GetInt("a");
        print("SCORE ACUMULADO START:" + scoreStored);

        scoreStored2 = PlayerPrefs.GetInt("b");
        print("SCORE ACUMULADO SEGUNDO START:" + scoreStored2);



        UIBackground = GameObject.Find("PanelImageBackground").GetComponent<Image>();
        //claimR1 = gameObject.GetComponent<Missions>().claimedR1;
        currentScoreText.text = currentScore.ToString();
        YourScoreText.text = currentScore.ToString();
        GetBestScore();
        randomBackground = Random.Range(1, 8);
        print("RANDOM"+randomBackground);
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

        //Currency
        getCurrency();
    }

    void Update()
    {
        Missions missions = gameObject.GetComponent<Missions>();
        if (missions.claimedR2 == true)
        {
            scoreAcumlated = 0;
            PlayerPrefs.SetInt("a", scoreAcumlated);
        }

        if (missions.claimedR4 == true)
        {
            scoreAcumlated2 = 0;
            PlayerPrefs.SetInt("b", scoreAcumlated2);
        }
    }

    void GetBestScore()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    void getCurrency()
    {
        currencyText.text = PlayerPrefs.GetInt("Currency", 0).ToString();
    }


    public void AddScore()
    {
        Missions missions = gameObject.GetComponent<Missions>();

        currentScore++;
        currentScoreText.text = currentScore.ToString();
        YourScoreText.text = currentScore.ToString();

        if (currentScore > 0)
        {
            scoreAcumlated = PlayerPrefs.GetInt("a");
            scoreAcumlated = scoreAcumlated + 1;
            print("SCORE ACUMULADO TIEMPO REAL: " + scoreAcumlated);
            PlayerPrefs.SetInt("a", scoreAcumlated);
        }

        if (missions.mission01 == true && missions.claimedR2 == true)
        {
            print("Se cumplieron las condiciones");
            scoreAcumlated2 = PlayerPrefs.GetInt("b");
            scoreAcumlated2 = scoreAcumlated2 + 1;
            print("SCORE SEGUNDO: " + scoreAcumlated2);
            PlayerPrefs.SetInt("b", scoreAcumlated2);
        }





        //Currency
        if (premium == false)
        {
            if (currentScore % 10 == 0)
            {
                currency++;

                saveCurrency = PlayerPrefs.GetInt("Currency", saveCurrency) + 1;
                PlayerPrefs.SetInt("Currency", saveCurrency);
                currencyText.text = PlayerPrefs.GetInt("Currency", saveCurrency).ToString();
                
                currencyPlus.text = "+" + currency.ToString();
                StartCoroutine(showCurrency());
            }
        }
        else
        {

            currencyPlus.GetComponent<Text>().text = "+2";
            if (currentScore % 10 == 0)
            {
                currency = currency + 2;
                StartCoroutine(showCurrency());
            }
        }
        //End currency

        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            bestScoreText.text = currentScore.ToString();
            PlayerPrefs.SetInt("BestScore", currentScore);
        }

    }

    //Show +1    
    IEnumerator showCurrency()
    {
        currencyBonus.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        currencyBonus.SetActive(false);
    }
}

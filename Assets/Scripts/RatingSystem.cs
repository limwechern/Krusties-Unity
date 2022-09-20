using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RatingSystem : MonoBehaviour
{
    public static bool easyLevel;
    public static bool mediumLevel;
    public static bool hardLevel;


    bool pattyOnPlate = false;
    bool cheeseOnPlate = false;
    bool bottomBunOnPlate = false;
    bool topBunOnPlate = false;
    bool cucumberOnPlate = false;
    bool lettuceOnPlate = false;
    bool tomatoOnPlate = false;

    public int finalScore = 0;
    int points = 10;

    public Text finalScoreText;
    public GameObject hud;
    public GameObject levelCompleteScreen;
    public GameObject finalScoreDisplay;

    public AudioSource levelCompleteSFX;
    //bool plateOnTable = false;

    public TextMeshProUGUI HeaderText;

    public Image[] stars;
    public Sprite starYellow;
    //public Image starsAwarded;

    //public float pattyCookedFor;
    //public float cookedPattyTime;
    //public float burntPattyTime;

    public int pattyScore = -10;
    public int ketchup = 0;

    public int totalCollectedStars;

    private void Start()
    {
        

        Debug.Log("RatingSystem Activated");
        hud.SetActive(false);
        levelCompleteScreen.SetActive(true);
        GameObject.FindGameObjectWithTag("UI").GetComponent<GameOverScreen>().levelComplete = true;
        Debug.Log("Level Complete [Rating System]");
        levelCompleteSFX.Play();

        finalScoreDisplay.SetActive(true);

        finalScore = CalculateScore();
        Debug.Log("Score : " + finalScore);

        AwardStars();

        string displayScore = finalScore.ToString();

        finalScoreText.text = "Score : " + displayScore;
    }


    

    public void AwardStars()
    {

        if (finalScore >= 10 && finalScore < 20)
        {
            stars[0].sprite = starYellow;
            Debug.Log("1 Star");
            HeaderText.SetText("Nice Work!");
            CheckLevelForStars(1);

        }
        else if (finalScore >= 20 && finalScore < 40)
        {
            stars[0].sprite = starYellow;
            stars[1].sprite = starYellow;
            Debug.Log("2 Stars");
            HeaderText.SetText("Good Job!");
            CheckLevelForStars(2);
        }
        else if (finalScore >= 40 && finalScore < 60)
        {
            stars[0].sprite = starYellow;
            stars[1].sprite = starYellow;
            stars[2].sprite = starYellow;
            Debug.Log("3 Stars");
            HeaderText.SetText("Excellent!");
            CheckLevelForStars(3);
        }
        else if (finalScore >= 60 && finalScore < 80)
        {
            stars[0].sprite = starYellow;
            stars[1].sprite = starYellow;
            stars[2].sprite = starYellow;
            stars[3].sprite = starYellow;
            Debug.Log("4 Stars");
            HeaderText.SetText("Epic!");
            CheckLevelForStars(4);
        }
        else if (finalScore >= 80)
        {
            stars[0].sprite = starYellow;
            stars[1].sprite = starYellow;
            stars[2].sprite = starYellow;
            stars[3].sprite = starYellow;
            stars[4].sprite = starYellow;
            Debug.Log("5 Stars");
            HeaderText.SetText("Legendary!");
            CheckLevelForStars(5);
        }
        else
        {
            Debug.Log("0 Stars");
            CheckLevelForStars(0);
        }
    }

    public void CheckLevelForStars(int starsAwarded)
    {

        StarsCollected.totalCollectedStarsEasy = starsAwarded;
        Debug.Log("Stars Awarded to Playfab : " + starsAwarded);

        /*
        if (easyLevel)
        {
            //StarsCollected.totalCollectedStarsEasy += starsAwarded;
            //Debug.Log("Stars Awarded to Playfab : " + starsAwarded);
            //PlayfabManager playfabMananger = GameObject.Find("PlayfabManager").GetComponent<PlayfabManager>();
            //playfabMananger.SendLeaderboard(totalCollectedStars);
        }
        else if (mediumLevel)
        {
            StarsCollected.totalCollectedStarsMedium += starsAwarded;
        }
        else if (hardLevel)
        {
            StarsCollected.totalCollectedStarsHard += starsAwarded;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "Table")
        {
            Debug.Log("Plate on Table");
            plateOnTable = true;
            levelCompleteSFX.Play();

            //GetComponent<OnPlate>().enabled = true;
            
        }
        */

        if (other.gameObject.tag == "Patty")
        {
            Debug.Log("Patty on Plate");
            pattyOnPlate = true;
            GameObject.FindGameObjectWithTag("Patty").GetComponent<PattyCooking>().pattyOnPlate = true;
        }

        if (other.gameObject.tag == "Cheese")
        {
            Debug.Log("Cheese on Plate");
            cheeseOnPlate = true;
        }

        if (other.gameObject.tag == "BottomBun")
        {
            Debug.Log("BottomBun on Plate");
            bottomBunOnPlate = true;
            finalScore += points;
        }

        if (other.gameObject.tag == "TopBun")
        {
            Debug.Log("TopBun on Plate");
            topBunOnPlate = true;
        }

        if (other.gameObject.tag == "Cucumber")
        {
            Debug.Log("Cucumber on Plate");
            cucumberOnPlate = true;
        }

        if (other.gameObject.tag == "Lettuce")
        {
            Debug.Log("Lettuce on Plate");
            lettuceOnPlate = true;
        }

        if (other.gameObject.tag == "Tomato")
        {
            Debug.Log("Tomato on Plate");
            tomatoOnPlate = true;
        }

        
    }

    int CalculateScore()
    {
        if (pattyOnPlate)
        {
            finalScore += pattyScore;
        }
        

        if (ketchup == 3)
        {
            finalScore += points + points;
        }
        
        if (cheeseOnPlate)
        {
            finalScore += points;
        }
        if (topBunOnPlate)
        {
            finalScore += points;
        }
        if (bottomBunOnPlate)
        {
            finalScore += points;
        }
        if (cucumberOnPlate)
        {
            finalScore += points;
        }
        if (lettuceOnPlate)
        {
            finalScore += points;
        }
        if (tomatoOnPlate)
        {
            finalScore += points;
        }


        

        return finalScore;
    }
}

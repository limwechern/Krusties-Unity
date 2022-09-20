using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;

public class StarsCollected : MonoBehaviour
{
    public static int totalCollectedStarsEasy;
    public static int totalCollectedStarsMedium;
    public static int totalCollectedStarsHard;
    public static int totalCollectedStars;

    //public TextMeshProUGUI EasyLevelStars;
    //public TextMeshProUGUI MediumLevelStars;
    //public TextMeshProUGUI HardLevelStars;


    // Start is called before the first frame update
    void Start()
    {
        //EasyLevelStars.SetText(totalCollectedStarsEasy.ToString());
        //MediumLevelStars.SetText(totalCollectedStarsMedium.ToString());
        //HardLevelStars.SetText(totalCollectedStarsHard.ToString());
        totalCollectedStars += totalCollectedStarsEasy; //+ totalCollectedStarsMedium + totalCollectedStarsHard;
        PlayfabManager playfabMananger = GameObject.Find("PlayfabManager").GetComponent<PlayfabManager>();
        playfabMananger.SendLeaderboard(totalCollectedStars);

        //EasyLevelStars.SetText(totalCollectedStars.ToString());
        Debug.Log("total collected stars : " + totalCollectedStars);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

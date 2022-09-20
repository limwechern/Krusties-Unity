using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;


public class PlayfabManager : MonoBehaviour
{
    [Header("Name UI")]
    public GameObject nameUI;
    //public GameObject leaderboardWindow;
    public TextMeshProUGUI nameInput;
    public string playerName;
    public bool playerNameExist;
    public int totalAccumulatedStars;
    string loggedInPlayfabId;

    [Header("Leaderboard")]
    public GameObject rowPrefab;
    public Transform rowsParent;

    public GameObject leaderboardUI;
    public GameObject difficultyMenuUI;


    // Start is called before the first frame update
    void Start()
    {
        Login();
        //GetLeaderboardAroundPlayer();
        
        /*
        if (playerNameExist)
        {
            //difficultyMenuUI.SetActive(true);
            nameUI.SetActive(false);
            leaderboardUI.SetActive(false);

        }
        else
        {
            nameUI.SetActive(true);
            difficultyMenuUI.SetActive(false);
            leaderboardUI.SetActive(false);
        }
        */

        //totalAccumulatedStars = item.StatValue.ToString();
        //OnLeaderboardAroundPlayerGet(0);
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
        GetLeaderboardAroundPlayer();
    }

    void OnLoginSuccess(LoginResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        
        Debug.Log("Successful login/account created!");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        name = result.InfoResultPayload.PlayerProfile.DisplayName;

        if (name == null)
        {
            nameUI.SetActive(true);
            difficultyMenuUI.SetActive(false);
            leaderboardUI.SetActive(false);
        }    
        else
        {
            nameUI.SetActive(false);
            //difficultyMenuUI.SetActive(true);
            leaderboardUI.SetActive(false);
        }
    }
    



    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
            
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);

        playerName = nameInput.text;
        playerNameExist = true;

        nameUI.SetActive(false);
        difficultyMenuUI.SetActive(true);
        leaderboardUI.SetActive(false);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
        //leaderboardUI.SetActive(true);
    }


    
    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }




    public void SendLeaderboard (int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Krusties",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate (UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful Leaderboard Sent");
    }

    public void GetLeaderboard()
    {
        leaderboardUI.SetActive(true);
        difficultyMenuUI.SetActive(false);

        var request = new GetLeaderboardRequest
        {
            StatisticName = "Krusties",
            StartPosition = 0,
            MaxResultsCount = 10
            
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Krusties",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }



    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if (item.PlayFabId == loggedInPlayfabId)
            {
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;

                
                //Get player's total stars from the cloud
                totalAccumulatedStars = item.StatValue;
                StarsCollected.totalCollectedStars = totalAccumulatedStars;
                Debug.Log("Get player's total Stars : " + totalAccumulatedStars);
                
            }
            
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }





    void OnLeaderboardGet (GetLeaderboardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);

            /*
            if (item.PlayFabId == loggedInPlayfabId)
            {
                //Get player's total stars
                totalAccumulatedStars = item.StatValue;
                StarsCollected.totalCollectedStars = totalAccumulatedStars;
            }
            */
        }
    }


    public void backButton()
    {
        difficultyMenuUI.SetActive(true);
        leaderboardUI.SetActive(false);

    }

}

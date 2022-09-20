using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameObject difficultyMenu;

    public bool isGameActive;
    public int time; //set to any in inspector

    public void StartGame(int difficulty)
    {
        time /= difficulty;
        isGameActive = true;
        StartCoroutine(StartTimer());
        UpdateTime(time);
        //difficultyMenu.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator StartTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            time--;
            UpdateTime(time);
        }
    }

    private void UpdateTime(int time)
    {
        timeText.text = "Time: " + time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

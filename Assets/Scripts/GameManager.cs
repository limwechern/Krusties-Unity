using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton; 


    private int score;
    public bool isGameActive;

    public int time; //set to 60 in inspector

    private void Start()
    {
        

    }

    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void startGame(int difficulty)
    {


        //spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(StartTimer());
        UpdateTime(time);
        //StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
    }

    

    IEnumerator StartTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            time--;
            UpdateTime(time);

            if (time < 1)
            {
                GameOver();
            }
        }
    }

    private void UpdateTime(int time)
    {
        timeText.text = "Time: " + time;
    }


    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

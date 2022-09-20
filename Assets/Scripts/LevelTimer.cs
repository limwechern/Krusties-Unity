using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI HeaderText;
    public bool gameOver = false;

    public GameObject hud;
    public GameObject levelCompleteScreen;

    public AudioSource gameplaySFX;

    float currentTime = 0f;
    public float startingTime = 12f;
    public float yellowTime = 60f;
    public float redTime = 20f; 
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        gameplaySFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = "Time Left: " + currentTime.ToString("0");

        if (currentTime >= yellowTime)
        {
            timerText.color = Color.green;
        }

        if (currentTime < yellowTime)
        {
            timerText.color = Color.yellow;
        }

        if (currentTime < redTime)
        {
            timerText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            Debug.Log("Finish Game");
            GameObject.FindGameObjectWithTag("Plate").GetComponent<RatingSystem>().enabled = true;
            levelCompleteScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            gameplaySFX.Stop();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;

    


    //public AudioSource mainMenuSFX;


    // Start is called before the first frame update
    void Start()
    {
        //button = GetComponent<Button>();
        //button.onClick.AddListener(SetDifficulty);
        // Difficulties Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        //gameManager.StartGame(difficulty);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void easyButton()
    {
        //mainMenuSFX.Stop();
        SceneManager.LoadScene("EasyLevel");
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusic>().levelLoading = true;
        Debug.Log("Easy Button Pressed");
        RatingSystem.easyLevel = true;
        RatingSystem.mediumLevel = false;
        RatingSystem.hardLevel = false;
    }

    public void mediumButton()
    {
        //mainMenuSFX.Stop();
        SceneManager.LoadScene("MediumLevel");
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusic>().levelLoading = true;
        RatingSystem.easyLevel = false;
        RatingSystem.mediumLevel = true;
        RatingSystem.hardLevel = false;
    }

    public void hardButton()
    {
        //mainMenuSFX.Stop();
        SceneManager.LoadScene("HardLevel");
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusic>().levelLoading = true;
        RatingSystem.easyLevel = false;
        RatingSystem.mediumLevel = false;
        RatingSystem.hardLevel = true;
    }
}

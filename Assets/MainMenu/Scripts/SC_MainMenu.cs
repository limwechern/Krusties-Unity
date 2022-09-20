using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        //Show Difficulty Menu
        MainMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void SettingsButton()
    {
        // Show Settings Menu
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
        Debug.Log("Quit!");
    }

   
}

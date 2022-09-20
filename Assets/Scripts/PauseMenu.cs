using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    public AudioSource pauseMenuSFX;
    public AudioSource gameplaySFX;
    public AudioSource footstepsSFX;

    private void Update()
    {
        if (GameIsPaused)
        {
            footstepsSFX.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void RestartGame()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuSFX.Stop();
        gameplaySFX.Play();


        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuSFX.Play();
        gameplaySFX.Pause();
        
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void menuButton()
    {
        Resume();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("DifficultyScene");
    }

}

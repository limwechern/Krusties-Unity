using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public AudioSource levelCompleteSFX;
    public AudioSource gameplaySFX;
    public AudioSource footstepsSFX;
    public bool levelComplete = false;



    private void Update()
    {
        
        if (levelComplete == true)
        {
            gameOver();
        }
        else
        {
            levelCompleteSFX.Stop();
            //Debug.Log("Level NOT complete");
        }
        
    }



    public void gameOver()
    {
        gameplaySFX.Stop();
        footstepsSFX.Stop();
        //levelCompleteSFX.Play();
        //Debug.Log("Level IS complete");
    }

    public void RestartGame()
    {
        levelCompleteSFX.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        levelComplete = false;
    }

    public void MainMenuButton()
    {
        levelCompleteSFX.Stop();
        SceneManager.LoadScene("DifficultyScene");
        levelComplete = false;

    }

    

}

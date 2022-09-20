using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SC_DifficultyMenu : MonoBehaviour
{

    public GameObject DifficultyMenu;

    void Start()
    {
        //DifficultyButton();
    }

    public void DifficultyButton()
    {
        DifficultyMenu.SetActive(true);
    }

    public void BackButton()
    {
        //Show Main Menu
        SceneManager.LoadScene("MenuScene");

    }
}

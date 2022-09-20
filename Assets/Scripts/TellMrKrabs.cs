using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TellMrKrabs : MonoBehaviour
{
    public Text finalScoreText;
    public GameObject hud;
    public GameObject levelCompleteScreen;

    
    public int finalScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Finish Game");
            GameObject.FindGameObjectWithTag("Plate").GetComponent<RatingSystem>().enabled = true;
            levelCompleteScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }


    }
}

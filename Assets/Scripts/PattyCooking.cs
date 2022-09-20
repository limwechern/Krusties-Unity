using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PattyCooking : MonoBehaviour
{
    private bool pattyOnGrill = false;
    public AudioSource fryPatty;

    public float cookedPattyTime = 10;
    public float burntPattyTime = 15;

    public TextMeshProUGUI PattyTimerText;
    private float startTime;
    

    public Material[] material;
    Renderer rend;

    public float pattyCookedFor;
    float floatMinutes;
    float floatSeconds;

    public int points = 10;

    public GameObject pattyTimer;
    public bool pattyOnPlate;
    //public bool pattyUnCooked = true;
    //public bool pattyCookedPerfect = false;
    //public bool pattyOverCooked = false ;

    public int pattyScore = -10;
    


    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grill" && pattyCookedFor < burntPattyTime)
        {

            Debug.Log("Patty on Grill");
            pattyOnGrill = true;
            fryPatty.Play();
            startTime = Time.time;

            pattyTimer.SetActive(true);

            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Grill")
        {
            pattyCookedFor = floatSeconds;
            Debug.Log("Patty off Grill");
            Debug.Log(floatSeconds);
            pattyOnGrill = false;
            fryPatty.Stop();

            pattyTimer.SetActive(false);


            
            if (pattyCookedFor < cookedPattyTime)
            {
                GameObject.FindGameObjectWithTag("Plate").GetComponent<RatingSystem>().pattyScore = -10;
                Debug.Log("Patty Uncooked");

            }
            else if (pattyCookedFor >= cookedPattyTime && pattyCookedFor < burntPattyTime)
            {
                GameObject.FindGameObjectWithTag("Plate").GetComponent<RatingSystem>().pattyScore = 20;
                Debug.Log("Patty Cooked Perfectly");
            }
            else
            {
                GameObject.FindGameObjectWithTag("Plate").GetComponent<RatingSystem>().pattyScore = -10;
                Debug.Log("Patty Overcooked");
            }


            startTime = pattyCookedFor;
        }
        
    }


    private void Update()
    {
        if (pattyOnGrill)
        {
            

            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            floatMinutes = ((int)t / 60);
            floatSeconds = (t % 60);

            
            PattyTimerText.text = minutes + ":" + seconds;


            //Over 10 seconds, change the patty color to brown
            if (floatSeconds >= cookedPattyTime)
            {
                rend.sharedMaterial = material[1];
                //pattyCookedPerfect = true;
            }
            
            if (floatSeconds >= burntPattyTime)
            {
                rend.sharedMaterial = material[2];
                //pattyOverCooked = true;
            }





            if (floatSeconds >= cookedPattyTime && floatSeconds < burntPattyTime)
            {
                PattyTimerText.color = Color.green;
            }

            if (floatSeconds < cookedPattyTime)
            {
                PattyTimerText.color = Color.yellow;
            }

            if (floatSeconds >= burntPattyTime)
            {
                PattyTimerText.color = Color.red;
            }
        }
    }

    
}



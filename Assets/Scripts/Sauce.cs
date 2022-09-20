using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sauce : MonoBehaviour
{
    public bool onSaucePlate;
    public int ketchup = 0;

    public GameObject KetchupText;
    public GameObject Ketchup1;
    public GameObject Ketchup2;
    public GameObject Ketchup3;
    public GameObject Ketchup4;
    public GameObject Ketchup5;
    public GameObject Ketchup6;
    public GameObject Ketchup7;

    public TextMeshProUGUI NoOfKetchup;

    public AudioSource onPlate;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lettuce")
        {
            Debug.Log("Lettuce on Sauce Plate");
            onSaucePlate = true;
            SaucePump.onSaucePlate = true;

            onPlate.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Lettuce")
        {
            Debug.Log("Lettuce off Sauce Plate");
            onSaucePlate = false;

            SaucePump.onSaucePlate = false;
        }
    }
    

    private void Update()
    {
        if (onSaucePlate && Input.GetKeyDown("k"))
        {
            SaucePump.playKetchupPump = true;
            GameObject.FindGameObjectWithTag("Plate").GetComponent<RatingSystem>().ketchup += 1;
            ketchup += 1;
            NoOfKetchup.SetText("Ketchup Pump : " + ketchup.ToString());
            //Debug.Log(ketchup);
            KetchupText.SetActive(true);
            Invoke("SetFalse", 2.0f); // disable after 2 seconds
            if (ketchup == 1)
            {
                Ketchup1.SetActive(true);
            }
            else if (ketchup == 2)
            {
                Ketchup2.SetActive(true);
            }
            else if (ketchup == 3)
            {
                Ketchup3.SetActive(true);
            }
            else if (ketchup == 4)
            {
                Ketchup4.SetActive(true);
            }
            else if (ketchup == 5)
            {
                Ketchup5.SetActive(true);
            }
            else if (ketchup == 6)
            {
                Ketchup6.SetActive(true);
            }
            else if (ketchup == 7)
            {
                Ketchup7.SetActive(true);
            }
        }

        
        
    }

    void SetFalse()

    {

        KetchupText.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucePump : MonoBehaviour
{
    public static bool playKetchupPump;
    public static bool onSaucePlate;
    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k") && onSaucePlate)
        {
            //GetComponent<Animator>().Play("KetchupPump");
            //playKetchupPump = false;
            GetComponent<Animator>().Play("KetchupPump", -1, 0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.18f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool recipeIsDisplayed = false;
    bool hotkeyIsDisplayed = false;

    public AudioSource footSteps;
    public GameObject recipeUI;
    public GameObject hotkeysUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (recipeIsDisplayed)
        {
            footSteps.Stop();
        }

        if (Input.GetKeyDown("r"))
        {
            
            if (recipeIsDisplayed == false)
            {
                recipeUI.SetActive(true);
                recipeIsDisplayed = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                recipeUI.SetActive(false);
                recipeIsDisplayed = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;

            }
        }

        if (Input.GetKeyDown("h"))
        {

            if (hotkeyIsDisplayed == false)
            {
                hotkeysUI.SetActive(true);
                hotkeyIsDisplayed = true;
            }
            else
            {
                hotkeysUI.SetActive(false);
                hotkeyIsDisplayed = false;
                
            }
        }



        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            
        }

        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //if (Input.GetAxis("Horizontal"))
        //Debug.Log(x);
        

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        /*
        if (x != 0 && z != 0 && footSteps.isPlaying == false)
        {
            footSteps.Play();
            
        }
        else
        {
            
            Debug.Log("NO Footsteps SFX");

        }
        */

        
        if ((Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")) && footSteps.isPlaying == false)
        {
            footSteps.Play();
            //Debug.Log("Footsteps SFX");
            
        }
        else
        {
            
            //Debug.Log("NO Footsteps SFX");
        }
        
    }


    public void footstepsSFX()
    {
        footSteps.Play();
        //Debug.Log("Footsteps SFX");
    }
}

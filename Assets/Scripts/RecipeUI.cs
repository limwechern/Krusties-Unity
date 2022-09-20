using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeUI : MonoBehaviour
{
    public bool ingredientsButton;
    public bool stepsButton;

    public GameObject IngredientsUI;
    public GameObject StepsUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IngredientsButton()
    {
        ingredientsButton = true;
        stepsButton = false;

        StepsUI.SetActive(false);
        IngredientsUI.SetActive(true);
    }

    public void StepsButton()
    {
        ingredientsButton = false;
        stepsButton = true;

        StepsUI.SetActive(true);
        IngredientsUI.SetActive(false);
    }
}

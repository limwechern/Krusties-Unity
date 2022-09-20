using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    public bool levelLoading = false;

    void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
            Debug.Log("Playing Menu backgournd music");
        }

        else
        {
            Destroy(gameObject);
            Debug.Log("NOT Playing Menu backgournd music");
        }
    }


    private void Update()
    {
        if (levelLoading == false)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
            //Debug.Log("Playing Menu backgournd music");
        }

        else
        {
            Destroy(gameObject);
            //Debug.Log("NOT Playing Menu backgournd music");
        }
    }
}

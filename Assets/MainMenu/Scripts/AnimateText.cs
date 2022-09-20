using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimateText : MonoBehaviour
{
    public List<CanvasGroup> textHolder = new List<CanvasGroup>();
    public List<Text> textDisplayBox = new List<Text>();
    public List<string> dialogue = new List<string>();

    public string nextScene;
    int whichText = 0;
    int positionInString = 0;
    Coroutine textPusher;

    IEnumerator WritetheText()
    {
        for(int i = 0; i <= dialogue[whichText].Length; i++)
        {
            textDisplayBox[whichText].text = dialogue[whichText].Substring(0, i);
            positionInString++;
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        textPusher = StartCoroutine(WritetheText());
    }

    public void ProceedText()
    {
        if(positionInString<dialogue[whichText].Length)
        {
            StopCoroutine(textPusher);
            textDisplayBox[whichText].text = dialogue[whichText];
            positionInString = dialogue[whichText].Length;
        }
        else
        {
            textHolder[whichText].alpha = 0;
            textHolder[whichText].interactable = false;
            textHolder[whichText].blocksRaycasts = false;
            whichText++;
        }
        if(whichText >=textDisplayBox.Count)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            positionInString = 0;
            textHolder[whichText].alpha = 1;
            textHolder[whichText].interactable = true;
            textHolder[whichText].blocksRaycasts = true;
            textPusher = StartCoroutine(WritetheText());
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

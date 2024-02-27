using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;


public class Microphone : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary <string, Action> wordToAction;
    public Start start;
    void Start()
    {
        wordToAction = new Dictionary <string, Action> ();
        wordToAction.Add("escanear", Scan);
        wordToAction.Add("volver", Back); 

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordReconized;
        keywordRecognizer.Start(); 
    
    }

    public void WordReconized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text); 
        wordToAction[word.text].Invoke();
    }
    public void Scan()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
     public void Back()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }

}

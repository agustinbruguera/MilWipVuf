using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceRecognicer : MonoBehaviour

{
public GameObject ContinuousVoiceRecorder;
public string Command; 


public  void Update()
    {
        Command = ContinuousVoiceRecorder.GetComponent<ContinuousVoiceRecorder>().ResultText;

        if(Command.Contains("b"))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            Debug.Log("Anda");
        }
        else Debug.Log("Don't command recognized)");
    }
}

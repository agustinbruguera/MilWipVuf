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

        if(Command.Contains("c"))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        else Debug.Log("");
    }
}

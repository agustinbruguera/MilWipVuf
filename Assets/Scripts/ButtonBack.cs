using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;


public class ButtonBack : MonoBehaviour
{
    public void Volver()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);


    }

    public void BackToScanner()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}

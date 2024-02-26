using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Start : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();

    }
}

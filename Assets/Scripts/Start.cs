using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

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

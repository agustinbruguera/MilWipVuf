using UnityEngine;
using UnityEngine.SceneManagement;


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

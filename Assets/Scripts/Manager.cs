using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using WearHFPlugin;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public SimpleBarcodeScanner SimpleBarcodeScanner;
    public List<Sprite> imageList = new List<Sprite>();
    public GameObject manager;
    private WearHF wearHf;
    public List<string> commandScanList = new List<string>() {"scan", "escanear", "escaneo", "escanea", "escaniar","scann","scanner","escaner"};

    public List<string> commandMenuList = new List<string>() {"menu", "menú", "meniu", "ménu", "méniu"};

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Esto mantiene el objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruye cualquier duplicado
        }
    }
    void Start()
    {
        GameObject wearHfManager = GameObject.Find("WearHFManager");
        if (wearHfManager != null)
        {
            wearHf = wearHfManager.GetComponent<WearHF>();
            if (wearHf != null)
            {
                foreach (var item in commandScanList)
                {
                    wearHf.AddVoiceCommand(item, toScan);
                }
                foreach (var item in commandMenuList)
                {
                    wearHf.AddVoiceCommand(item, toMenu);
                }
            }
            else
            {
                Debug.LogError("WearHF component not found on WearHFManager.");
            }
        }
        else
        {
            Debug.LogError("WearHFManager not found in the scene.");
        }
    }
    public void UpdateSpriteList(List<Sprite> newList)
    {
        imageList = newList;
    }

    void toScan(string AddVoiceCommand){
        if (SceneManager.GetActiveScene().name == "Menu"){
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    void toMenu(string AddVoiceCommand){
        if (SceneManager.GetActiveScene().name != "Menu"){
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}

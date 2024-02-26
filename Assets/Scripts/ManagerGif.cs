using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using UnityEngine.SceneManagement;

public class ManagerGif : MonoBehaviour
{
    public static ManagerGif Instance;
    public SimpleBarcodeScanner SimpleBarcodeScanner;
    public List<Sprite> imageList = new List<Sprite>();
    public GameObject managerGif;

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
    // void Start()
    // {

    // // SimpleBarcodeScanner = GameObject.FindGameObjectWithTag("Barcode").GetComponent<SimpleBarcodeScanner>();
        
    //     // imageList = SimpleBarcodeScanner.images;
    //     // Debug.Log("imagelist:"+imageList.Count);
    // }
    
    public void UpdateSpriteList(List<Sprite> newList)
    {
        imageList = newList;

    }
}


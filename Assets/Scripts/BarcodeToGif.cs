using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using JetBrains.Annotations;


public class BarcodeToGif : MonoBehaviour
{
    public TMPro.TextMeshProUGUI barcodeAsText;
    public UnityEngine.UI.Image displayedImage; // Referencia al componente Image en tu Canvas
    public Sprite defaultImage; // Una imagen predeterminada para mostrar cuando no hay c�digo QR detectado
    BarcodeBehaviour mBarcodeBehaviour;
    public List<Sprite> gif = new List<Sprite>();

    ManagerGif managerGif; 

    

    
    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
        displayedImage.enabled = false;
        displayedImage.sprite = defaultImage; // Mostrar una imagen predeterminada al inicio
    }

    // Update se llama una vez por frame
    void Update()
    {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            // Aqu�, asumiremos que InstanceData.Text contiene la ruta al archivo de imagen dentro de Resources
            // o alg�n identificador que puedas mapear a una imagen.
            string imageFileName = mBarcodeBehaviour.InstanceData.Text;
            string[] gifList = imageFileName.Split(",");

            foreach(var item in gifList)
            {
                Sprite newGif = Resources.Load<Sprite>("Gif/" + item);
                gif.Add(newGif);
            }

            if (gif[0] != null) // Detecta si el elemento item 0 existe
            {
                ManagerGif.Instance.UpdateSpriteList(gif);
                SceneManager.LoadScene("GifView", LoadSceneMode.Single);
                
            }
            else Debug.Log("QR Invalid");
            barcodeAsText.text = "Code QR Invalid";
            
        }
        else
        {
            displayedImage.enabled = false;
            displayedImage.sprite = defaultImage; // No se detecta QR, mostrar imagen predeterminada
            barcodeAsText.text = "";
        }
    }

    
     
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;


public class SimpleBarcodeScanner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI barcodeAsText;
    public UnityEngine.UI.Image displayedImage; // Referencia al componente Image en tu Canvas
    public Sprite defaultImage; // Una imagen predeterminada para mostrar cuando no hay c�digo QR detectado
    BarcodeBehaviour mBarcodeBehaviour;
    public List<Sprite> images = new List<Sprite>();

    Manager manager; 

    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
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
            string[] imageList = imageFileName.Split(",");

            foreach(var item in imageList)
            {
                Sprite newSprite = Resources.Load<Sprite>("Images/" + item);
                images.Add(newSprite);
            }

            if (images.Count > 0)
            {
                Manager.Instance.UpdateSpriteList(images);
                SceneManager.LoadScene("ImageView", LoadSceneMode.Single);
            }
            else Debug.Log("No newSprite");
        }
        else
        {
            displayedImage.enabled = false;
            displayedImage.sprite = defaultImage; // No se detecta QR, mostrar imagen predeterminada
            barcodeAsText.text = "";
        }
    }

     
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using TMPro;
using Unity.VisualScripting;

public class ImageView : MonoBehaviour
{
    public UnityEngine.UI.Image displayedImage; 
    public Sprite defaultImage;
    public TMPro.TextMeshProUGUI imageText;
    public List<Sprite> imageList = new List<Sprite>();
    public int item;

    void Start()
    {
        item = 0;
        List<Sprite> imageList = Manager.Instance.imageList;
        Debug.Log("imagelist:" + imageList.Count);
        
        displayedImage.sprite = imageList[item];
        displayedImage.enabled = true;
        
    }
    
    public void NextImage()
    {
        List<Sprite> imageList = Manager.Instance.imageList; // Tuve que volver a llamarla sino me saltaba como lista vacia (miss)

    if (imageList != null && imageList.Count > 0) // Comprobamos que la lista sea valida (este dentro de rango)
    {
        // Incrementar item (sprites)
        item = (item + 1) % imageList.Count;

        // Actualizar la imagen mostrada si el numero de items es valido
        if (item >= 0 && item < imageList.Count)
        {
            displayedImage.sprite = imageList[item];
            displayedImage.enabled = true;
            Debug.Log("item = " + item);
        }
        else
        {
            Debug.LogError("Item fuera de rango: " + item);
        }
    }
    else
    {
        Debug.LogError("La lista de imágenes está vacía.");
    }
    }

    public void PreviousImage()
    {
        List<Sprite> imageList = Manager.Instance.imageList; // Tuve que volver a llamarla sino me saltaba como lista vacia (miss)

    if (imageList != null && imageList.Count > 0) // Comprobamos que la lista sea valida (este dentro de rango)
    {
        // Incrementar item (sprites)
        item = (item - 1 + imageList.Count) % imageList.Count;
        

        // Actualizar la imagen mostrada si el numero de items es valido
        if(item >= 0 && item < imageList.Count)
        {
            displayedImage.sprite = imageList[item];
            displayedImage.enabled = true;
            Debug.Log("item = " + item);
        }
        else
        {
            Debug.LogError("Item fuera de rango: " + item);
        }
    }
    else
    {
        Debug.LogError("La lista de imágenes está vacía.");
    }
    }

    public void BackToScanner()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}

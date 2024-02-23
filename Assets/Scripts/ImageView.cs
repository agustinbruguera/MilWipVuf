using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using System;

public class ImageView : MonoBehaviour
{
    public UnityEngine.UI.Image displayedImage; 
    public Sprite defaultImage;
    public TMPro.TextMeshProUGUI imageText;
    public List<Sprite> imageList = new List<Sprite>();

    [SerializeField]
    private int item;

    void Start()
    {
        item = 0;

        List<Sprite> imageList = Manager.Instance.imageList;
    
        displayedImage.sprite = imageList[0];
        displayedImage.enabled = true;
        
    }
 
    public void NextImage()
    {
        List<Sprite> imageList = Manager.Instance.imageList;

        if (imageList != null && imageList.Count > 0)
        {
            item = (item + 1) % imageList.Count;
            Debug.Log("item = " + item);

            displayedImage.sprite = imageList[item];
            displayedImage.enabled = true;
        }
        else
        {
            Debug.LogError("La lista de imágenes está vacía.");
        }
    }

    public void PreviousImage()
    {
        List<Sprite> imageList = Manager.Instance.imageList;

        if (imageList != null && imageList.Count > 0)
        {
            item = (item - 1 + imageList.Count) % imageList.Count;
            Debug.Log("item = " + item);

            displayedImage.sprite = imageList[item];
            displayedImage.enabled = true;
        }
        else
        {
            Debug.LogError("La lista de imágenes está vacía.");
        }
        
    }


    
}
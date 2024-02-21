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
        item = item + 1;
        Debug.Log("item =" + item);
        displayedImage.sprite = imageList[item];


    }
}

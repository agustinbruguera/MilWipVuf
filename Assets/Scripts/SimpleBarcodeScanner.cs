using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using WearHFPlugin;



public class SimpleBarcodeScanner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI barcodeAsText;
    public UnityEngine.UI.Image displayedImage; 
    public Sprite defaultImage; 
    BarcodeBehaviour mBarcodeBehaviour;
    public List<Sprite> images = new List<Sprite>();

   
   
    
    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
        displayedImage.enabled = false;
        displayedImage.sprite = defaultImage; 
    }

    void Update()
    {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            
            string imageFileName = mBarcodeBehaviour.InstanceData.Text;
            string[] imageList = imageFileName.Split(",");

            foreach(var item in imageList)
            {
                Sprite newSprite = Resources.Load<Sprite>("Images/" + item);
                images.Add(newSprite);
            }

            if (imageList[0].Contains("pdf"))
            { 
                Manager.Instance.UpdateSpriteList(images);
                SceneManager.LoadScene("ImageView", LoadSceneMode.Single);
            }
            else if(imageList[0].Contains("frame"))
            {
                Manager.Instance.UpdateSpriteList(images);
                SceneManager.LoadScene("GifView", LoadSceneMode.Single);
            }
            else Debug.Log("QR Invalid");
            barcodeAsText.text = "Code QR Invalid";
            displayedImage.enabled = true;
            displayedImage.sprite = Resources.Load<Sprite>("images/Error");
            

            
        }
        else
        {
            displayedImage.enabled = false;
            displayedImage.sprite = defaultImage; // No se detecta QR, mostrar imagen predeterminada
            barcodeAsText.text = "";
        }

        
    }   
     
}
using System.Collections.Generic;
using UnityEngine;
using WearHFPlugin;
using UnityEngine.SceneManagement;

public class ImageView : MonoBehaviour
{
    public UnityEngine.UI.Image displayedImage; 
    public Sprite defaultImage;
    public TMPro.TextMeshProUGUI imageText;
    public List<Sprite> imageList = new List<Sprite>();
    public List<string> commandBackList = new List<string>() {"back", "atras", "anterior", "volver", "previous"};
    public List<string> commandNextList = new List<string>() {"next", "siguiente", "adelante", "continuar"};

    [SerializeField]
    private int item;
    private WearHF wearHf;

    void Start()
    {
        item = 0;

        GameObject wearHfManager = GameObject.Find("WearHFManager");
        if (wearHfManager != null)
        {
            wearHf = wearHfManager.GetComponent<WearHF>();
            if (wearHf != null)
            {
                foreach (var item in commandBackList)
                {
                    wearHf.AddVoiceCommand(item, PreviousImage);
                }
                foreach (var item in commandNextList)
                {
                    wearHf.AddVoiceCommand(item, NextImage);
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

        List<Sprite> imageList = Manager.Instance.imageList;
    
        displayedImage.sprite = imageList[0];
        displayedImage.enabled = true;
        
    }
 
    public void NextImage(string AddVoiceCommand)
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
            Debug.LogError("La lista de im�genes est� vac�a.");
        }
    }

    public void PreviousImage(string AddVoiceCommand)
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
            Debug.LogError("La lista de im�genes est� vac�a.");
        }
        
    }


    
}
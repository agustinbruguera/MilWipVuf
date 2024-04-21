using System.Collections.Generic;
using UnityEngine;

public class GifView : MonoBehaviour
{
    public UnityEngine.UI.Image displayedImage; 
    public Sprite defaultImage;
    public TMPro.TextMeshProUGUI imageText;
    public List<Sprite> imageList = new List<Sprite>();
    
    public float imageChangeInterval = 0.3f; // Intervalo de tiempo entre cambios de sprite en segundos
    private float timer = 0f;

    [SerializeField]
    private int item;
    

    public void Start()
    {
        

        List<Sprite> imageList = Manager.Instance.imageList;
    
        displayedImage.sprite = imageList[0];
        displayedImage.enabled = true;
        
    }

    public void Update()
    {
        List<Sprite> imageList = Manager.Instance.imageList;

        if (imageList.Count > 0)
        {
            // Actualiza el temporizador
            timer += Time.deltaTime;

            // Comprueba si ha pasado el tiempo suficiente para cambiar de imagen
            if (timer >= imageChangeInterval)
            {
                // Reinicia el temporizador
                timer = 0f;

                // Incrementa el índice del elemento para mostrar el siguiente
                item = (item + 1) % imageList.Count;
                displayedImage.sprite = imageList[item];
                Debug.Log("item = " + item);
            }
        }
        else
        {
            Debug.Log("La lista de GIFs está vacía.");
        }
    }

}
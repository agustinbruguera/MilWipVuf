using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con UI Image
using Vuforia;

public class SimpleBarcodeScanner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI barcodeAsText;
    public UnityEngine.UI.Image displayedImage; // Referencia al componente Image en tu Canvas
    public Sprite defaultImage; // Una imagen predeterminada para mostrar cuando no hay código QR detectado
    BarcodeBehaviour mBarcodeBehaviour;

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
            // Aquí, asumiremos que InstanceData.Text contiene la ruta al archivo de imagen dentro de Resources
            // o algún identificador que puedas mapear a una imagen.
            barcodeAsText.text = mBarcodeBehaviour.InstanceData.Text;
            string imageFileName = mBarcodeBehaviour.InstanceData.Text;
            Sprite newSprite = Resources.Load<Sprite>("Images/" + imageFileName);

            if (newSprite != null)
            {
                Debug.Log("newSprite");
                displayedImage.sprite = newSprite; // Actualizar la imagen mostrada
                displayedImage.enabled = true;
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

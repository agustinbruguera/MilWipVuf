using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prueba : MonoBehaviour
{

    public string puntos;
    public TMPro.TextMeshProUGUI PuntosTexto;

    // Start is called before the first frame update
    void Start()
    {
        PuntosTexto.text = "Hola Mundo";
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarTexto();
    }

    void ActualizarTexto(){
        PuntosTexto.text = puntos;
    }

}

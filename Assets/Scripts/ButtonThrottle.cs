using UnityEngine;
using System.Collections;

public class ButtonThrottle : MonoBehaviour
{
    public float throttleDuration = 0.5f; // Tiempo en segundos antes de que el bot�n pueda ser presionado nuevamente
    private bool isButtonThrottled = false; // Controla si el bot�n est� actualmente en "throttle"

    // Este m�todo ser�a llamado por tu bot�n para ejecutar la acci�n deseada
    public void OnButtonPressed()
    {
        if (isButtonThrottled) return; // No hacer nada si el bot�n est� en throttle

        Debug.Log("Bot�n presionado");

        // Aqu� ir�a la l�gica que quieres ejecutar cuando se presione el bot�n

        StartCoroutine(ThrottleButton());
    }

    // Coroutine que maneja el throttle del bot�n
    private IEnumerator ThrottleButton()
    {
        isButtonThrottled = true; // Activa el throttle
        yield return new WaitForSeconds(throttleDuration); // Espera por la duraci�n del throttle
        isButtonThrottled = false; // Desactiva el throttle
    }
}

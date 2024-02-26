using UnityEngine;
using System.Collections;

public class ButtonThrottle : MonoBehaviour
{
    public float throttleDuration = 0.5f; // Tiempo en segundos antes de que el botón pueda ser presionado nuevamente
    private bool isButtonThrottled = false; // Controla si el botón está actualmente en "throttle"

    // Este método sería llamado por tu botón para ejecutar la acción deseada
    public void OnButtonPressed()
    {
        if (isButtonThrottled) return; // No hacer nada si el botón está en throttle

        Debug.Log("Botón presionado");

        // Aquí iría la lógica que quieres ejecutar cuando se presione el botón

        StartCoroutine(ThrottleButton());
    }

    // Coroutine que maneja el throttle del botón
    private IEnumerator ThrottleButton()
    {
        isButtonThrottled = true; // Activa el throttle
        yield return new WaitForSeconds(throttleDuration); // Espera por la duración del throttle
        isButtonThrottled = false; // Desactiva el throttle
    }
}

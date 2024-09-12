using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento del proyectil
    public float tiempoDeVida = 2f; // Tiempo antes de que el proyectil se destruya automáticamente
    private Rigidbody2D rb; // Referencia al Rigidbody2D del proyectil

    void Start()
    {
        // Obtener la referencia al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("No se encontró el componente Rigidbody2D en el proyectil.");
            return;
        }

        // Establecer la velocidad del proyectil
        rb.velocity = transform.up * velocidad;

        // Mostrar en consola la velocidad asignada al proyectil para depuración
        Debug.Log("Velocidad asignada al proyectil: " + rb.velocity);

        // Destruir el proyectil después de un tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica la colisión con la nave enemiga
        if (other.CompareTag("NaveEnemiga"))
        {
            Destroy(other.gameObject); // Destruye la nave enemiga
            Destroy(gameObject); // Destruye el proyectil

            // Incrementa el puntaje
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.IncrementarScore(10); // Incrementa el puntaje en 10 (ajusta según sea necesario)
            }
            else
            {
                Debug.LogError("No se encontró el GameManager en la escena.");
            }
        }
    }
}

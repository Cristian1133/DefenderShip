using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMosca : MonoBehaviour
{
    public float velocidad = 5f;
    public AudioClip sonidoExplosion;

    private AudioSource audioSource;

    void Start()
    {
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no se encontró en NaveMosca.");
        }
    }

    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);

        if (transform.position.y < -6)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.IncrementarMissed(1);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Proyectil"))
        {
            Debug.Log("Reproduciendo sonido de explosión");
            // Reproducir sonido de explosión
            if (audioSource != null && sonidoExplosion != null)
            {
                audioSource.PlayOneShot(sonidoExplosion);
            }
            else
            {
                Debug.LogError("AudioSource o sonidoExplosion no está asignado.");
            }

            // Resto del código...
        }
    }
}
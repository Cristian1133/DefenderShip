using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveDefensora : MonoBehaviour
{
    public AudioClip sonidoDisparo; // Clip de sonido para el disparo
    private AudioSource audioSource; // Referencia al componente AudioSource
    public GameObject proyectilPrefab; // Prefab del proyectil que se disparará
    public Transform puntoDeDisparo; // Punto desde donde se disparará el proyectil
    public float velocidad = 5f; // Velocidad de movimiento de la nave

    void Start()
    {
        // Intenta obtener el componente AudioSource adjunto a la nave
        audioSource = GetComponent<AudioSource>();

        // Verifica si el componente AudioSource está presente
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource no encontrado en el GameObject. Asegúrate de que el GameObject tenga un componente AudioSource.");
        }
    }

    void Update()
    {
        // Movimiento de la nave defensora
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * movimientoHorizontal * velocidad * Time.deltaTime);

        // Disparo del proyectil cuando se presiona el botón de disparo
        if (Input.GetButtonDown("Fire1")) // Asegúrate de que el botón de disparo esté configurado en los Input Settings
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        // Verifica si el punto de disparo y el prefab del proyectil están asignados
        if (puntoDeDisparo == null)
        {
            Debug.LogError("Punto de disparo no asignado. Asegúrate de asignar un punto de disparo en el Inspector.");
            return;
        }

        if (proyectilPrefab == null)
        {
            Debug.LogError("Prefab de proyectil no asignado. Asegúrate de asignar un prefab de proyectil en el Inspector.");
            return;
        }

        // Instancia el proyectil en el punto de disparo
        Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Reproduce el sonido del disparo si el sonido y el AudioSource están asignados
        if (sonidoDisparo != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoDisparo);
        }
        else
        {
            Debug.LogWarning("Sonido de disparo no asignado o AudioSource no encontrado.");
        }
    }
}

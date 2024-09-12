using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNavesEnemigas : MonoBehaviour
{
    public GameObject naveEnemigaPrefab;
    public float tiempoEntreGeneraciones = 2f;
    public float rangoX = 10f;
    public float rangoY = 5f;

    private void Start()
    {
        InvokeRepeating("GenerarNave", 0f, tiempoEntreGeneraciones);
    }

    void GenerarNave()
    {
        float posX = Random.Range(-rangoX, rangoX);
        float posY = Random.Range(-rangoY, rangoY);

        Vector2 posicionGeneracion = new Vector2(posX, posY);
        Instantiate(naveEnemigaPrefab, posicionGeneracion, Quaternion.identity);
    }
}
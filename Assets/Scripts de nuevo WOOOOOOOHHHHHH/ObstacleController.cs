using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public float radioGeneracion = 10f;
    public float radioSeparacionMinima = 2f;
    public int cantidadEnemigos = 10;

    public List<GameObject> enemigosGenerados = new List<GameObject>();

    void Start()
    {
        GenerarEnemigos();
    }

    void GenerarEnemigos()
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            Vector3 posicionAleatoria = ObtenerPosicionAleatoria();
            GameObject enemigoGenerado = Instantiate(enemigoPrefab, posicionAleatoria, Quaternion.identity);
            enemigosGenerados.Add(enemigoGenerado);
        }
    }

    public Vector3 ObtenerPosicionAleatoria()
    {
        Vector3 posicionAleatoria;
        bool posicionValida = false;

        do
        {
            float randomX = Random.Range(-radioGeneracion, radioGeneracion);
            float randomZ = Random.Range(-radioGeneracion, radioGeneracion);
            posicionAleatoria = transform.position + new Vector3(randomX, 0f, randomZ);


            posicionValida = EsPosicionValida(posicionAleatoria);
        } while (!posicionValida);

        return posicionAleatoria;
    }

    public bool EsPosicionValida(Vector3 posicion)
    {
        Collider[] colliders = Physics.OverlapSphere(posicion, radioSeparacionMinima);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Obstacle"))
            {
                return false;
            }
        }

        return true;
    }
}

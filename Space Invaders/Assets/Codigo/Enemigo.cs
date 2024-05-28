using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject disparoEnemigo;
    public Transform puntoDisparo;
    public float intervaloMinDisparo = 1f;
    public float intervaloMaxDisparo = 5f;
    ContadorEnemigos contadorEnemigos;

    private void Start()
    {
        StartCoroutine(DispararMisiles());
    }

    private IEnumerator DispararMisiles()
    {
        while (true)
        {
            float intervaloDisparo = Random.Range(intervaloMinDisparo, intervaloMaxDisparo);
            yield return new WaitForSeconds(intervaloDisparo);
            DispararMisil();
        }
    }

    private void DispararMisil()
    {
        Vector3 puntoDisparo = transform.position;
        GameObject disparo = Instantiate(disparoEnemigo, puntoDisparo, Quaternion.identity);
        disparo.GetComponent<DisparoEnemigo>().Inicializar(Vector2.down); 
    }
  
    private void OnDestroy()
    {
        if (contadorEnemigos != null)
        {
            contadorEnemigos.EnemigoDestruido();
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("DisparoJugador"))
        {
            Destroy(colision.gameObject);
            Destroy(gameObject);
        }
    }

}

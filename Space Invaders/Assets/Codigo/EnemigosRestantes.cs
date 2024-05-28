using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ContadorEnemigos : MonoBehaviour
{
    public int enemigosRestantes;
    public Text textoContadorEnemigos;


    private void Start()
    {
        enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        ActualizarContadorEnemigos();
    }

    public void EnemigoDestruido()
    {
        enemigosRestantes--;
        ActualizarContadorEnemigos();

        if (enemigosRestantes <= 0)
        {
           SceneManager.LoadScene("Ganar");
        }
    }

    private void ActualizarContadorEnemigos()
    {
        textoContadorEnemigos.text = "Enemigos Restantes: " + enemigosRestantes;   
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar las escenas

public class Pausa : MonoBehaviour
{
    public GameObject menuPausa; // Referencia al menú de pausa en la escena
    public bool juegoPausado = false; // Estado del juego (pausado o no)

    private void Update()
    {
        // Detecta si se presiona la tecla Escape o P
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    // Método para pausar el juego
    public void Pausar()
    {
        juegoPausado = true;
        menuPausa.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0f; // Detiene el tiempo del juego
    }

    // Método para reanudar el juego
    public void Reanudar()
    {
        juegoPausado = false;
        menuPausa.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1f; // Restaura el tiempo del juego
    }

    // Método para salir al menú principal
    public void SalirAlMenu()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        SceneManager.LoadScene("MenuInicio"); // Carga la escena del menú principal (asegúrate de tenerla en Build Settings)
    }
}

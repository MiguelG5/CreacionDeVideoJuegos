using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaPanelController : MonoBehaviour
{
    public GameObject panelVictoria; // Panel de victoria
    public GameObject panelNiveles;  // Panel de niveles

    // Método para reiniciar el nivel actual
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia el nivel actual
    }

    // Método para ir al menú principal
    public void SalirAlMenu()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        SceneManager.LoadScene("MenuInicio"); // Carga la escena del menú principal (asegúrate de tenerla en Build Settings)
    }

    // Método para mostrar el panel de niveles
    public void VerNiveles()
    {
        panelVictoria.SetActive(false); // Oculta el panel de victoria
        panelNiveles.SetActive(true);   // Muestra el panel de niveles
    }

    // Método para cargar un nivel específico desde el panel de niveles
    public void CargarNivel(int nivelIndex)
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        SceneManager.LoadScene(nivelIndex); // Carga el nivel seleccionado según su índice
    }

    // Método para regresar al panel de victoria
    public void RegresarAlPanelVictoria()
    {
        panelVictoria.SetActive(true);  // Muestra el panel de victoria
        panelNiveles.SetActive(false);  // Oculta el panel de niveles
    }
}

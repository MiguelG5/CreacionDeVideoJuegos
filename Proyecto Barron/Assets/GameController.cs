using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int vidas = 3; // Vidas del jugador
    public int numerosParesAgarrados = 0; // Contador de números pares
    public int numerosParesMeta = 5; // Cantidad necesaria para ganar
    public Text contadorParesTexto; // UI Text para mostrar los números pares agarrados
    public Image[] corazones; // Array de imágenes para mostrar las vidas
    public GameObject panelVictoria; // Panel de victoria
    public GameObject panelGameOver; // Panel de Game Over

    void Start()
    {
        ActualizarVidas();
        ActualizarContadorPares();
    }

    // Método para aumentar el contador de números pares
    public void AumentarContadorPares()
    {
        numerosParesAgarrados++;
        ActualizarContadorPares();

        // Verifica si el jugador ha ganado
        if (numerosParesAgarrados >= numerosParesMeta)
        {
            MostrarPanelVictoria();
        }
    }

    // Método para disminuir las vidas del jugador
    public void PerderVida()
    {
        vidas--;
        ActualizarVidas();

        if (vidas <= 0)
        {
            MostrarPanelGameOver();
        }
    }

    // Actualiza el contador de números pares en la UI
    void ActualizarContadorPares()
    {
        if (contadorParesTexto != null)
        {
            contadorParesTexto.text = "Pares: " + numerosParesAgarrados + " / " + numerosParesMeta;
        }
    }

    // Actualiza la UI de vidas
    void ActualizarVidas()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = (i < vidas);
        }
    }

    // Muestra el panel de victoria
    void MostrarPanelVictoria()
    {
        Time.timeScale = 0f; // Pausa el juego
        panelVictoria.SetActive(true); // Muestra el panel de victoria
    }

    // Muestra el panel de Game Over
    void MostrarPanelGameOver()
    {
        Time.timeScale = 0f; // Pausa el juego
        panelGameOver.SetActive(true); // Muestra el panel de Game Over
    }

    // Métodos para los botones del panel Victoria y Game Over
    public void SiguienteNivel()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        int siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1; // Calcula el siguiente nivel
        SceneManager.LoadScene(siguienteNivel); // Carga el siguiente nivel
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia el nivel actual
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        SceneManager.LoadScene("MenuInicio"); // Carga la escena del menú principal
    }
}

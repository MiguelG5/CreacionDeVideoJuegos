using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // Instancia estática

    public int vidas = 3; // Vidas del jugador
    public int numerosParesAgarrados = 0; // Contador de números pares
    public int numerosParesMeta = 5; // Cantidad necesaria para ganar
    public Text contadorParesTexto; // UI Text para mostrar los números pares agarrados
    public Text puntuacionTexto; // UI Text para mostrar la puntuación en el panel de victoria
    public Image[] corazones; // Array de imágenes para mostrar las vidas
    public GameObject panelVictoria; // Panel de victoria
    public GameObject panelGameOver; // Panel de Game Over
    public Text tiempoTexto; // Texto para mostrar el tiempo en UI
    public Slider barraDeTiempo; // Referencia al slider para la barra de tiempo

    private int puntuacionNivel = 100; // Puntos por pasar el nivel
    private int puntosPorVida = 50; // Puntos por cada vida restante
    public float tiempoLimite = 60f; // Tiempo en segundos para el nivel
    private float tiempoRestante; // Tiempo restante en el nivel

    void Awake()
    {
        // Si ya existe una instancia, destruir este objeto
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        ActualizarVidas();
        ActualizarContadorPares();
        tiempoRestante = tiempoLimite; // Inicializa el temporizador
        barraDeTiempo.maxValue = tiempoLimite; // Establece el valor máximo de la barra de tiempo
        barraDeTiempo.value = tiempoRestante; // Inicializa el valor de la barra de tiempo
    }

    void Update()
    {
        if (tiempoRestante > 0f)
        {
            tiempoRestante -= Time.deltaTime; // Resta el tiempo
            ActualizarBarraDeTiempo(); // Actualiza la barra de tiempo
        }
        else
        {
            tiempoRestante = 0f;
            MostrarPanelGameOver(); // Si el tiempo se acaba, muestra Game Over
        }
    }

    void ActualizarBarraDeTiempo()
    {
        if (barraDeTiempo != null)
        {
            barraDeTiempo.value = tiempoRestante; // Actualiza el valor del slider con el tiempo restante
        }
    }

    public void AumentarContadorPares()
    {
        numerosParesAgarrados++;
        ActualizarContadorPares();

        if (numerosParesAgarrados >= numerosParesMeta)
        {
            CalcularPuntuacion();
            MostrarPanelVictoria();
        }
    }

    public void PerderVida()
    {
        vidas--;
        ActualizarVidas();

        if (vidas <= 0)
        {
            MostrarPanelGameOver();
        }
    }

    void CalcularPuntuacion()
    {
        int puntosTotalesNivel = puntuacionNivel + (vidas * puntosPorVida);
        PuntuacionTotal.AgregarPuntos(puntosTotalesNivel);

        if (puntuacionTexto != null)
        {
            puntuacionTexto.text = "Puntuación: " + PuntuacionTotal.ObtenerPuntos();
        }
    }

    void ActualizarContadorPares()
    {
        if (contadorParesTexto != null)
        {
            contadorParesTexto.text = "Pares: " + numerosParesAgarrados + " / " + numerosParesMeta;
        }
    }

    void ActualizarVidas()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = (i < vidas);
        }
    }

    void MostrarPanelVictoria()
    {
        Time.timeScale = 0f;
        panelVictoria.SetActive(true);
    }

    void MostrarPanelGameOver()
    {
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }

    public void SiguienteNivel()
    {
        Time.timeScale = 1f;
        int siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(siguienteNivel);
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicio");
    }
}

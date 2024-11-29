using UnityEngine;

public class Numeros : MonoBehaviour
{
    public int numero;  // Número representado por este objeto
    public GameController gameController;  // Referencia al GameController

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // Verifica si colisiona con el jugador
        {
            if (numero % 2 == 0)  // Si el número es par
            {
                gameController.AumentarContadorPares();  // Aumentar el contador de números pares
                Destroy(gameObject);  // Destruir el objeto de número
            }
            else  // Si el número es impar
            {
                gameController.PerderVida();  // Perder una vida
                Destroy(gameObject);  // Destruir el objeto de número
            }
        }
    }
}

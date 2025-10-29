using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Método para iniciar el juego
    public void Jugar()
    {
        // Carga la escena del juego (asegúrate de que esté añadida en Build Settings)
        SceneManager.LoadScene("Nivel 1"); // Cambia por el nombre de tu escena de juego
    }

    // Método para mostrar créditos (si tienes otra escena)
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos"); // O muestra un panel si prefieres
    }

    // Método para salir del juego
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

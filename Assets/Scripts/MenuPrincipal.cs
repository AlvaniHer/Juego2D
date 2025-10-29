using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // M�todo para iniciar el juego
    public void Jugar()
    {
        // Carga la escena del juego (aseg�rate de que est� a�adida en Build Settings)
        SceneManager.LoadScene("Nivel 1"); // Cambia por el nombre de tu escena de juego
    }

    // M�todo para mostrar cr�ditos (si tienes otra escena)
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos"); // O muestra un panel si prefieres
    }

    // M�todo para salir del juego
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

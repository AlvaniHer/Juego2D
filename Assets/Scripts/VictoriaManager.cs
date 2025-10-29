using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoriaManager : MonoBehaviour
{
    public TextMeshProUGUI textoPuntos;

    void Start()
    {
        MostrarPuntos();
    }

    void MostrarPuntos()
    {
        // Mostrar los puntos que se recolectaron en el nivel
        if (GameManager.instance != null)
        {
            textoPuntos.text = "Cerezas recolectadas: " + GameManager.instance.puntos;
        }
        else
        {
            textoPuntos.text = "Cerezas recolectadas: 0";
        }
    }

    public void VolverAlMenu()
    {
        // Reiniciar puntos antes de volver al menú
        if (GameManager.instance != null)
        {
            GameManager.instance.ReiniciarPuntos();
        }
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void JugarDeNuevo()
    {
        // Reiniciar puntos
        if (GameManager.instance != null)
        {
            GameManager.instance.ReiniciarPuntos();
        }
        SceneManager.LoadScene("Nivel1");
    }
}

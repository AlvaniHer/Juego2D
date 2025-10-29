using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int puntos = 0;
    public TextMeshProUGUI textoPuntos;

    void Awake()
    {
        //para que se mantengan en la scena de victoria
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarTexto();
    }
    public void ReiniciarPuntos()
    {
        puntos = 0;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        textoPuntos.text = "Cerezas: "+puntos.ToString();
    }
}

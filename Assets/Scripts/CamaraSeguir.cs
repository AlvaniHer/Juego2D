using UnityEngine;

public class CamaraSeguir: MonoBehaviour
{
    public Transform jugador; // arrastra aquí tu jugador en el inspector
    public float suavizado = 0.1f;
    private Vector3 velocidad = Vector3.zero;

    private void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 destino = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, destino, ref velocidad, suavizado);
        }
    }
   
}

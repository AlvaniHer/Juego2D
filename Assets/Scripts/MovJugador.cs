using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class MovJugador:MonoBehaviour
{
    public float velocidad = 2f; //velocidad del jugador
    public Rigidbody2D rb;
    public Vector2 mov;
    public float movementX;
    public float movementY;
    public float fuerzaSalto = 4f; //lit fuerza de salto
    public LayerMask sueloLayer; //asigna la capa suelo aqui
    public Transform comprobadorSuelo; //un punto en los pies del personaje
    public float radioComprobador = 0.1f;
    public bool estaensuelo;

    public Transform target; //para el mov de la camara

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue movimientos)
    {
        // se leen las teclas del movimiento que hace el usuario
        mov = movimientos.Get<Vector2>();
        movementX = mov.x;
        movementY = mov.y;
        Debug.Log(mov.x + " , " + mov.y);

        if(movementX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movementX), 1, 1);
        }
        estaensuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobador, sueloLayer);

    }
    private void FixedUpdate()
    {
        // Creamos el vector de movimiento (X = horizontal)
        Vector2 movimiento = new Vector2(mov.x, 0f);

        // Aplicamos la velocidad al Rigidbody2D
        rb.linearVelocity = new Vector2(movimiento.x * velocidad, rb.linearVelocity.y);
        // mantenemos la velocidad vertical actual (gravedad)
        estaensuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobador, sueloLayer);
        
    }
    private void OnJump(InputValue movimientos)
    {
        if (estaensuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si toca la cereza
        if (collision.gameObject.tag == "Recoleccion")
        {
            // Reproducir sonido ANTES de destruir
            AudioSource audioSource = collision.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                AudioSource.PlayClipAtPoint(audioSource.clip, collision.transform.position);
            }
            GameManager.instance.SumarPuntos(1);
            Destroy(collision.gameObject);
        }
        // Si toca un enemigo
        if (collision.gameObject.tag == "Enemigo")
        {
            // Reproducir sonido de daño
            AudioSource audioSource = collision.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                AudioSource.PlayClipAtPoint(audioSource.clip, collision.transform.position);
            }
            ReiniciarNivel();
        }
        //cuando llega a la bandera 
        if (collision.gameObject.tag == "Fin")
        {
            Victoria();
        } 
        //Al caer
        if (collision.CompareTag("SueloMuerte"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }

    }
    void ReiniciarNivel()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Victoria()
    {
        // Cargar la escena de victoria
        SceneManager.LoadScene("Victoria"); // Cambia por el nombre de tu escena
    }

}

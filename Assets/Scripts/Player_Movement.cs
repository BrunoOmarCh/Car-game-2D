using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//Este player Moment se puede tiene de base el nivel 2 (No lo cambio por posibles errores)
public class Player_Movement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador.
    public float rotationSpeed = 5f; // Velocidad de rotaci�n del jugador.
    public int lives = 3; //Vidas del jugador
    public Text livesText; //// Texto que muestra las vidas del jugador.
    public Score_Manager scoreValue; // Referencia al administrador del puntaje.
    public GameObject gameOverPanel; // Panel de Game Over.
   
    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
  

    void Start()
    {
        // Oculta el panel de Game Over y restablece el tiempo.
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        // Actualiza el texto inicial de las vidas.
        livesText.text = "Lives: " + lives.ToString();// Actualiza el texto de vidas en la UI.
    }

    void Update()
    {
        // Llama a los m�todos de movimiento y de l�mite de posici�n en cada cuadro.
        Movement();
        Clamp();
    }

    void Movement()
    {
        // Movimiento hacia la derecha.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Mueve el jugador a la derecha.
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            // Rota suavemente hacia la derecha.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -10), rotationSpeed * Time.deltaTime);
        }

        // Movimiento hacia la izquierda.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Mueve el jugador a la izquierda.
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

            // Rota suavemente hacia la izquierda.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 143), rotationSpeed * Time.deltaTime);
        }

        // Si la rotaci�n no est� centrada, ajustarla gradualmente.
        if (transform.rotation.z != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), 10f * Time.deltaTime);
        }
    }

    void Clamp()
    {
        // Restricci�n manual del movimiento horizontal.
        if (transform.position.x < -2.58f)
        {
            transform.position = new Vector3(-2.58f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 2.58f)
        {
            transform.position = new Vector3(2.58f, transform.position.y, transform.position.z);
        }

        /*
        // Alternativa con Mathf.Clamp.
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -2.58f, 2.58f);
        transform.position = pos;
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Colisi�n con objetos de la etiqueta "Cars" (resta vidas).
        if (collision.gameObject.tag == "Cars")
        {
            Destroy(collision.gameObject); // Destruye el objeto.
            lives--;                      // Resta una vida.
            
            livesText.text = "Lives: " + lives.ToString();// Actualiza el texto de vidas en la UI.
                                                         
            //Si el carro choca se escucha sond effect
            if (lives > 0)
            {
                audioManager.PlaySFX(audioManager.crash);
            }
            // Si las vidas llegan a 0, termina el juego.
            if (lives <= 0)
            {
                audioManager.PlaySFX(audioManager.boom);
                // Muestra el panel de Game Over y detiene el tiempo.
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;

                // Pausar la m�sica de fondo.
                audioManager.PauseMusic();

                // Opcional: Reproducir el efecto de sonido de victoria.
                audioManager.PlaySFX(audioManager.death);
            }

        }


        // Colisi�n con objetos de la etiqueta "Cars" (resta vidas).
        if (collision.gameObject.tag == "Camion")
        {
            Destroy(collision.gameObject); // Destruye el objeto.
            audioManager.PlaySFX(audioManager.boom);
            gameOverPanel.SetActive(true);// Muestra el panel de Game Over y detiene el tiempo.
            Time.timeScale = 0;
            audioManager.PauseMusic(); // Pausar la m�sica de fondo.
            audioManager.PlaySFX(audioManager.death);
        }

        // Si colisiona con un objeto con la etiqueta "Coin", incrementa el puntaje.
        if (collision.gameObject.tag == "Coin")
        {
            audioManager.PlaySFX(audioManager.coins);
            scoreValue.score += 10; // Aumenta el puntaje.
            Destroy(collision.gameObject); // Destruye la moneda.
        }

        // Colisi�n con objetos de la etiqueta "Live" (incrementa vidas).
        if (collision.gameObject.tag == "Live")
        {
            audioManager.PlaySFX(audioManager.live);
            if (lives < 3) 
            {
                lives++;               // Incrementa las vidas.                    
                livesText.text = "Lives: " + lives.ToString();  // Actualiza el texto de vidas en la UI.
            }  
            Destroy(collision.gameObject); // Destruye el objeto de vida.
        }
    }
}

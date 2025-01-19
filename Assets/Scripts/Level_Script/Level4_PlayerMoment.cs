using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Level4_PlayerMoment : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador.
    public float rotationSpeed = 5f; // Velocidad de rotación del jugador.
    public int lives = 3; //Vidas del jugador
    public Text livesText; //// Texto que muestra las vidas del jugador.
    public Score_Manager scoreValue; // Referencia al administrador del puntaje.
    public GameObject gameOverPanel; // Panel de Game Over.

    AudioManager audioManager;



    void Start()
    {
        // Oculta el panel de Game Over y restablece el tiempo.
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        // Actualiza el texto inicial de las vidas.
        livesText.text = "Lives: " + lives.ToString();// Actualiza el texto de vidas en la UI.
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();// Encuentra el AudioManager y reproduce la música de fondo correctamente.
        audioManager.musicSource.clip = audioManager.background; // Asigna el clip al musicSource.
        audioManager.musicSource.Play(); // Reproduce la música de fondo.
    }

    void Update()
    {
        // Llama a los métodos de movimiento y de límite de posición en cada cuadro.
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

        // Movimiento hacia arriba.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);         
        }

        // Movimiento hacia abajo.
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        // Si la rotación no está centrada, ajustarla gradualmente.
        if (transform.rotation.z != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), 10f * Time.deltaTime);
        }
    }

    void Clamp()
    {
        // Restricción manual del movimiento horizontal.
        if (transform.position.x < -6.20f)
        {
            transform.position = new Vector3(-6.20f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 7.20f)
        {
            transform.position = new Vector3(7.2f, transform.position.y, transform.position.z);
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
        // Colisión con objetos de la etiqueta "Cars" (resta vidas).
        if (collision.gameObject.tag == "Cars" || collision.gameObject.tag == "Poste")
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
                // Muestra el panel de Game Over y detiene el tiempo.
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;

                // Pausar la música de fondo.
                audioManager.PauseMusic();

                // Opcional: Reproducir el efecto de sonido de victoria.
                audioManager.PlaySFX(audioManager.death);
            }

        }

        // Si colisiona con un objeto con la etiqueta "Coin", incrementa el puntaje.
        if (collision.gameObject.tag == "Coin")
        {
            audioManager.PlaySFX(audioManager.coins);
            scoreValue.score += 10; // Aumenta el puntaje.
            Destroy(collision.gameObject); // Destruye la moneda.
        }


        // Colisión con objetos de la etiqueta "Cars" (resta vidas).
        if (collision.gameObject.tag == "Camion")
        {
            Destroy(collision.gameObject); // Destruye el objeto.
            livesText.text = "Lives: " + "0";// Actualiza el texto de vidas en la UI a 0 
            audioManager.PlaySFX(audioManager.boom);
            gameOverPanel.SetActive(true);// Muestra el panel de Game Over y detiene el tiempo.
            Time.timeScale = 0;
            audioManager.PauseMusic(); // Pausar la música de fondo.
            audioManager.PlaySFX(audioManager.death);
        }

        // Colisión con objetos de la etiqueta "Live" (incrementa vidas).
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

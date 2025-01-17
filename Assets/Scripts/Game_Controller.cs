using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public Text highSoreText;
    public Text scoreText;
    public Text scorewinText;

    public Score_Manager score_manager;
    public GameObject gamePausePanel;
    public GameObject gamePauseButton;
    public GameObject gameWinPanel;
    public GameObject musicOpcion;

    private int score;
    private int highScore;
    private int targetScore;

    private bool hasWon = false; //Anadiendo un boolenao para que el win solo se llame un sola vez

    AudioManager audioManager;




    // Start is called before the first frame update
    void Start()
    {
        gamePausePanel.SetActive(false);
        gamePauseButton.SetActive(true);
        gameWinPanel.SetActive(false);
        musicOpcion.SetActive(false);
        Time.timeScale = 1; // Asegurarse de que el tiempo esté activo
        // Establecer el puntaje objetivo según la escena
        SetTargetScoreByScene();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Restart()
    {
        hasWon = false; // Reinicia la bandera
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score");
        score = score_manager.score;
        highSoreText.text = "Highscore: " + highScore.ToString();
        scoreText.text = "Score: " + score.ToString();
        scorewinText.text = "Score: " + score.ToString();
        // Verificar si el puntaje alcanza el objetivo y el juego no se ha ganado
        if (!hasWon && score >= targetScore)//Se pone un booleano porque si no se llama a la funcion sucesivamente generando conflictos
        {
            GameWin();
            hasWon = true; // Marcar como ganado
        }
    }

    private void SetTargetScoreByScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        // Define el puntaje objetivo basado en el nombre de la escena
        switch (currentScene)
        {
            case "Level1":
                targetScore = 100;
                break;
            case "Level2":
                targetScore = 200;
                break;
            case "Level3":
                targetScore = 300;
                break;
            default:
                targetScore = 200; // Puntaje por defecto
                break;
        }
    }

    private void GameWin()
    {
        gameWinPanel.SetActive(true);
        gamePauseButton.SetActive(false);
        Time.timeScale = 0;
        audioManager.PauseMusic();
        audioManager.PlaySFX(audioManager.win);
    }

   

    //Botones Pause
    public void PauseGame()
    {
        // Pausar la música de fondo.
        audioManager.PauseMusic();
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gamePauseButton.SetActive(false);
    }



    //Boton Resumen
    public void ResumeGame()
    {
        // Reanudar la música de fondo.
        audioManager.ResumeMusic();
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        gamePauseButton.SetActive(true); ;
        musicOpcion.SetActive(false);
    }

    //Botones Musica
    public void Opciones()
    {
        // Pausar la música de fondo.
        audioManager.PauseMusic();
        Time.timeScale = 0;
        musicOpcion.SetActive(true);
        gamePausePanel.SetActive(false);
    }

    public void NextLevel()
    {
        // Cargar la siguiente escena en el índice de construcción
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Verificar si existe un siguiente nivel
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No hay más niveles disponibles.");
            // Podrías mostrar un mensaje o redirigir al menú principal
        }
    }
}

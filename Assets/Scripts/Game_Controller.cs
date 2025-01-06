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

    private int score;
    private int highScore;
    private int targetScore;

    // Start is called before the first frame update
    void Start()
    {
        gamePausePanel.SetActive(false);
        gamePauseButton.SetActive(true);
        gameWinPanel.SetActive(false);
        Time.timeScale = 1; // Asegurarse de que el tiempo esté activo

        // Establecer el puntaje objetivo según la escena
        SetTargetScoreByScene();
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score");
        score = score_manager.score;

        highSoreText.text = "Highscore: " + highScore.ToString();
        scoreText.text = "Score: " + score.ToString();
        scorewinText.text = "Score: " + score.ToString();

        // Verificar si el puntaje alcanza el objetivo
        if (score >= targetScore)
        {
            GameWin();
        }
    }

    private void SetTargetScoreByScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Define el puntaje objetivo basado en el nombre de la escena
        switch (currentScene)
        {
            case "Level1":
                targetScore = 150;
                break;
            case "Level2":
                targetScore = 300;
                break;
            case "Level3":
                targetScore = 500;
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
        Time.timeScale = 0; // Pausar el juego
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gamePauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        gamePauseButton.SetActive(true);
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

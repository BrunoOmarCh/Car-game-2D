using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public Text highSoreText;
    public Text scoreText;

    private int score;
    private int highScore;
    public Text scorewinText;

    public Score_Manager score_manager;
    public GameObject gamePausePanel;
    public GameObject gamePauseButton;
    public GameObject gameWinPanel;
    // Start is called before the first frame update
    void Start()
    {
         gamePausePanel.SetActive(false);
         gamePauseButton.SetActive(true);
         gameWinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score");
        score = score_manager.score;

        highSoreText.text = "Highscore: " + highScore.ToString();
        scoreText.text = "Score: " + score.ToString();
        scorewinText.text = "Score: " + score.ToString();
        // Verificar si el puntaje llega a 500
        if (score >= 150)
        {
            // Mostrar el panel de victoria
            gameWinPanel.SetActive(true);
            // Ocultar el botón de pausa para evitar interacción
            gamePauseButton.SetActive(false);
            Time.timeScale = 0; 
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Siguiente");
    }
}

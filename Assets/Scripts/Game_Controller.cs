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

    public Score_Manager score_manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score");
        score = score_manager.score;

        highSoreText.text = "Highscore: " + highScore.ToString();
        scoreText.text = "Your Score: " + score.ToString();        
    }
        public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}

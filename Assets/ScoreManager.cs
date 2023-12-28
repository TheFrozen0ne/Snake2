using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {   
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }


    public void AddPoint() {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Collided with Obstacle");
                score = 0; // Reset the score to zero
                scoreText.text = "Score: " + score.ToString();
            }
        else
            {
                Debug.Log("Collision detected with: " + collision.gameObject.name);
            }
    
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }
}




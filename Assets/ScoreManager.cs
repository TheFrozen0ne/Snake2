using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // ... (other variables)
        void OnTriggerEnter2D(Collider2D trig)
    {
    if (trig.gameObject.name == "Food")
        {
            score += 1;
            Destroy(trig.gameObject);
        }
    }

    public void Death()
    {
        Debug.Log("Death");
        SceneManager.LoadScene ("Snake");
    }
}



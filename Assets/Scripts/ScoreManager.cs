using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public GameObject highScoreTitle1;
    public GameObject highScoreTitle2;

    public GameObject scoreGame1;
    public GameObject scoreGame2;

    public GameObject scoreGameOver;
    public GameObject highScoreGameOver;

    private int score;
    private int hightScore;

    static string HIGH_SCORE = "highScore";
    static string SCORE = "score";
    
    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        }

        hightScore = PlayerPrefs.GetInt(HIGH_SCORE);
    }

    void Start() {
        score = 0;

        highScoreTitle1.GetComponent<Text>().text = "Higest Score: " + ScoreManager.instance.hightScore;
        highScoreTitle2.GetComponent<Text>().text = highScoreTitle1.GetComponent<Text>().text;
    }

    public void UpdateScore() {
    }

    public void increaseScore(int points) {
        score += points;

        scoreGame1.GetComponent<Text>().text = "Score: " + score;
        scoreGame2.GetComponent<Text>().text = "Score: " + score;
    }

    void increaseScore() {
        increaseScore(1);
    }

    public void StartGame() {
        InvokeRepeating("increaseScore", 0.5f, 0.5f);

        PlayerPrefs.SetInt(SCORE, score);
    }

    public void EndGame() {
        CancelInvoke("increaseScore");

        if (PlayerPrefs.HasKey(HIGH_SCORE)) {
            if (PlayerPrefs.GetInt(HIGH_SCORE) < score) {
                hightScore = score;
            }
        } else {
            hightScore = score;
        }

        PlayerPrefs.SetInt(HIGH_SCORE, hightScore);
        
        scoreGameOver.GetComponent<Text>().text = score.ToString();
        highScoreGameOver.GetComponent<Text>().text = hightScore.ToString();
    }
}

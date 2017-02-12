using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool gameOver;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        gameOver = false;
    }

    public void StartGame() {
        UIManager.instance.StartGame();
        ScoreManager.instance.StartGame();
    }

    public void EndGame() {
        gameOver = true;

        UIManager.instance.EndGame();
        ScoreManager.instance.EndGame();
    }

    public void Reset() {
        SceneManager.LoadScene(0);
    }
}

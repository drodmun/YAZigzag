using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject startView;
    public GameObject gameView;
    public GameObject gameOverView;

    public GameObject tapToStart;
    public GameObject yatTitle;
    public GameObject highScoreTitle;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void StartGame() {
        tapToStart.GetComponent<Animator>().Play("tapToStartDown");
        yatTitle.GetComponent<Animator>().Play("yatUp");
        highScoreTitle.GetComponent<Animator>().Play("highScoreDown");

        gameView.SetActive(true);
        Invoke("hideStartView", 1f);
    }

    private void hideStartView() {
        startView.SetActive(false);
    }

    public void EndGame() {
        gameView.SetActive(false);
        gameOverView.SetActive(true);
    }
}

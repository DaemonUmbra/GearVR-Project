using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    Text debugText;
    Text scoreText;
    Text timeText;

	// Use this for initialization
	void Start () {

        debugText = GameObject.Find("DebugText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        timeText = GameObject.Find("TimerText").GetComponent<Text>();
#if !DEBUG
        debugText.enabled = false;
#endif
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetDebug(string text)
    {
        debugText.text = text;
    }

    public void SetScore(string text)
    {
        scoreText.text = "Score: " + text;
    }

    public void SetTime(string text)
    {
        timeText.text = "Seconds Left: " + text;
    }

    public void SetWin()
    {
        timeText.text = "You Win!";
    }

    public void SetLose()
    {
        timeText.text = "You Lose!";
    }
}

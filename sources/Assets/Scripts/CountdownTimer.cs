using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MyObject
{
    public float timeRemaining = 75;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Awake()
    {
        timeText = GetComponent<Text>();
    }

    protected override void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        base.Start();
    }

    protected override void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                gameManager.lose();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        // float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        // float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        int seconds = Mathf.FloorToInt(timeToDisplay);

        // timeText.text = string.Format("{1:00}", seconds);
        timeText.text = seconds.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Adapted from https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

public class Timer
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private Action action;

    private void Start()
    {
        timerIsRunning = false;
    }

    public void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                action();
                timerIsRunning = false;
            }
        }
    }

    public void startTimer(float TargetTime, Action action)
    {
        this.action = action;
        this.timeRemaining = TargetTime;
        timerIsRunning = true;
    }
}

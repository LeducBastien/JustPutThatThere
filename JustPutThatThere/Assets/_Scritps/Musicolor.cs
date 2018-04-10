﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicolor : MonoBehaviour {

    private const int RESET_TIME = 3;

    private float timer = 0;
    private bool timerStarted = false;

    private string value;

    private readonly List<string> codes = new List<string>();
    private readonly List<Action> actions = new List<Action>();

    Musicolor()
    {
        codes.Add("0102010");
        actions.Add(UnlockClapetKey);

        value = "";
    }

    public void Reset()
    {
        value = "";
        timerStarted = false;
    }

    public void ButtonPressed(string digit)
    {
        if(value == "")
        {
            StartTimer();
        }
        value += digit;
        timer = 0;
        CompareCodes();
    }

    private void StartTimer ()
    {
        timer = 0;
        timerStarted = true;
    }

    private void StopTimer ()
    {
        timerStarted = false;
    }

    private void CompareCodes()
    {
        for (var i = 0; i < codes.Count; i++)
        {
            if (codes[i] == value)
            {
                actions[i]();
                Reset();
            }
        }
    }

    private void UnlockClapetKey ()
    {
        print("unlocked clapet key");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timerStarted)
        {
            timer += Time.deltaTime;
            if (timer > RESET_TIME)
            {
                print("time out");
                StopTimer();
                Reset();
            }
        }
	}
}

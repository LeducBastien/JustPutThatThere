using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingBase : MonoBehaviour {

    private const float DOWN_SPEED = 25f;
    private const float DOWN_DISTANCE = 80f;

    private float startingY;

    private Action doAction;
	// Use this for initialization
	void Start () {
        doAction = DoActionVoid;
	}
	
	// Update is called once per frame
	void Update () {
        doAction();
	}

    public void StartEntrance()
    {
        startingY = transform.position.y;
        doAction = DoActionEntrance;
    }

    private void DoActionEntrance()
    {
        var position = transform.position;
        if(position.y < startingY - DOWN_DISTANCE)
        {
            position.y = startingY - DOWN_DISTANCE;
            EntranceFinished();
        }
        else
        {
            position.y -= DOWN_SPEED * Time.deltaTime;
        }
        transform.position = position;
    }

    private void EntranceFinished()
    {
        doAction = DoActionVoid;
    }

    private void DoActionVoid()
    {

    }
}

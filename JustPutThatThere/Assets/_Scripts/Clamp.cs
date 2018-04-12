using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour {

    private const float DISTANCE = 15f;
    private const float SPEED = 10f;

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
        position.y += SPEED * Time.deltaTime;
        if(position.y > startingY + DISTANCE)
        {
            position.y = startingY + DISTANCE;
            doAction = DoActionVoid;
        }

        transform.position = position;
    }

    private void DoActionVoid()
    {

    }
}

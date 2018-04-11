using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {

    private const float STARTING_Y = 50f;

    private const float DESCEND_DISTANCE = 100f;
    private const float DOWN_SPEED = 30f;
    private const float UP_SPEED = 50f;

    private const float MAX_X_DISTANCE = 50f;
    private const float HORIZONTAL_SPEED = 25f;

    private bool ready = true;

    [SerializeField] GameObject thread;
    [SerializeField] GameObject clamp;

    private Action doAction;

    // Use this for initialization
    void Start () {
        SetModeVoid();
	}
	
	// Update is called once per frame
	void Update () {
        doAction();
	}

    public void Descend()
    {
        if (ready)
        {
            ready = false;
            doAction = DoActionDown;
        }
    }

    public void GoRight()
    {
        if(ready)
            doAction = DoActionRight;
    }

    public void GoLeft()
    {
        if(ready)
            doAction = DoActionLeft;
    }

    private void SetModeGrab()
    {
        doAction = DoActionGrab;
    }

    private void DoActionGrab()
    {
        SetModeUp();
    }

    private void DoActionRight()
    {
        var position = thread.transform.localPosition;
        if(position.x > MAX_X_DISTANCE)
        {
            position.x = MAX_X_DISTANCE;
            SetModeVoid();
        }else
        {
            position.x += HORIZONTAL_SPEED * Time.deltaTime;
        }
        thread.transform.localPosition = position;
    }

    private void DoActionLeft()
    {
        var position = thread.transform.localPosition;
        if(position.x < -MAX_X_DISTANCE)
        {
            position.x = -MAX_X_DISTANCE;
            SetModeVoid();
        } else
        {
            position.x -= HORIZONTAL_SPEED * Time.deltaTime;
        }
        thread.transform.localPosition = position;
    }

    private void DoActionUp()
    {
        var position = thread.transform.localPosition;
        if(position.y > STARTING_Y)
        {
            position.y = STARTING_Y;
            SetModeVoid();
        }
        else
        {
            position.y += UP_SPEED * Time.deltaTime;
        }
        thread.transform.localPosition = position;
    }

    private void SetModeUp()
    {
        doAction = DoActionUp;
    }

    private void DoActionDown()
    {
        var position = thread.transform.localPosition;
        if (position.y < STARTING_Y - DESCEND_DISTANCE)
        {
            position.y = STARTING_Y - DESCEND_DISTANCE;
            SetModeGrab();
        }
        else
        {
            position.y -= DOWN_SPEED * Time.deltaTime;
        }
        thread.transform.localPosition = position;
    }

    private void SetModeVoid()
    {
        ready = true;
        doAction = DoActionVoid;
    }

    private void DoActionVoid()
    {

    }
}

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
    private const float THREAD_HEIGHT = 100f;

    private const float CLAMP_WIDTH = 30f;
    private const float CLAMP_HEIGHT = 30f;

    private const float ENTRANCE_DISTANCE = 100f;
    private const float ENTRANCE_SPEED = 45f;

    private float startingY;

    private bool ready = false;
    public bool onClamp = false;
    public bool clampAttached = false;

    [SerializeField] GameObject thread;
    [SerializeField] GameObject clamp;

    private Action doAction;

    // Use this for initialization
    void Start () {
        doAction = DoActionVoid;
	}
	
	// Update is called once per frame
	void Update () {
        doAction();
	}

    public void AttachClamp()
    {
        var clampTransform = clamp.transform;
        clampTransform.SetParent(thread.transform, true);
        clampAttached = true;
        SetModeUp();
    }

    public void Descend()
    {
        if (ready)
        {
            ready = false;
            doAction = DoActionDown;
        }
    }

    public void StartEntrance()
    {
        startingY = transform.position.y;
        doAction = DoActionEntrance;
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

    private void DoActionEntrance()
    {
        var position = transform.position;
        position.y -= ENTRANCE_SPEED * Time.deltaTime;
        if (position.y < startingY - ENTRANCE_DISTANCE)
        {
            position.y = startingY - ENTRANCE_DISTANCE;
            EndEntrance();
        }
        transform.position = position;
    }

    private void EndEntrance()
    {
        ready = true;
        doAction = DoActionVoid;
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

        if(!clampAttached)
            CheckClampCollision();
    }

    private void CheckClampCollision()
    {
        var threadPosition = thread.transform.position;
        var clampPosition = clamp.transform.position;

        if(threadPosition.y - THREAD_HEIGHT / 2 < clampPosition.y + CLAMP_HEIGHT / 2)
        {
            if(threadPosition.x > clampPosition.x - CLAMP_WIDTH / 2 && threadPosition.x < clampPosition.x + CLAMP_WIDTH / 2)
            {
                threadPosition.x = clampPosition.x;
                thread.transform.position = threadPosition;
                ClampCollide();
            }
        }
    }

    private void ClampCollide()
    {
        onClamp = true;
        doAction = DoActionVoid;
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

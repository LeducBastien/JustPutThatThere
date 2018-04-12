using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {

    private const float STARTING_Y = 50f;

    private const float DESCEND_DISTANCE = 100f;
    private const float DOWN_SPEED = 30f;
    private const float UP_SPEED = 50f;

    private const float MAX_X_DISTANCE = 70f;
    private const float HORIZONTAL_SPEED = 25f;
    private const float THREAD_HEIGHT = 100f;

    private const float CLAMP_WIDTH = 30f;
    private const float CLAMP_HEIGHT = 30f;

    private const float BABY_WIDTH = 45f;
    private const float BABY_HEIGHT = 45f;

    private const float HOLE_WIDTH = 60f;
    private const float HOLE_HEIGHT = 20f;

    private const float ENTRANCE_DISTANCE = 100f;
    private const float ENTRANCE_SPEED = 45f;

    private float startingY;

    private bool ready = false;
    public bool onClamp = false;
    public bool clampAttached = false;
    private bool babyGrabbed = false;
    private bool babySaved = false;

    [SerializeField] GameObject thread;
    [SerializeField] GameObject clamp;
    [SerializeField] Baby baby;
    [SerializeField] GameObject hole;
    [SerializeField] Transform canvasTransform;

    [SerializeField] AudioSource armdownSound;

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
            armdownSound.Play();
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
        if (ready)
        {
            armdownSound.Play();
            doAction = DoActionRight;
        }
    }

    public void GoLeft()
    {
        if (ready)
        {
            armdownSound.Play();
            doAction = DoActionLeft;
        }
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
        armdownSound.Play();
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

        if (!clampAttached)
            CheckClampCollision();
        else if (!babyGrabbed)
            CheckBabyCollision();
        else if (babyGrabbed && !babySaved)
            CheckHoleCollision();
    }

    private void CheckHoleCollision()
    {
        var holePosition = hole.transform.position;
        var babyPosition = baby.transform.position;

        if(babyPosition.y - BABY_HEIGHT / 2 < holePosition.y + HOLE_HEIGHT / 2)
        {
            if(babyPosition.x > holePosition.x - HOLE_WIDTH / 2 && babyPosition.x < holePosition.x + HOLE_WIDTH / 2)
            {
                babyPosition.x = holePosition.x;
                baby.transform.position = babyPosition;
                HoleCollide();
            }
        }
    }

    private void HoleCollide()
    {
        var babyTransform = baby.transform;
        babyTransform.SetParent(canvasTransform, true);
        babySaved = true;
        SetModeUp();
    }

    private void CheckBabyCollision()
    {
        var clampPosition = clamp.transform.position;
        var babyPosition = baby.transform.position;

        if(clampPosition.y - CLAMP_HEIGHT / 2 < babyPosition.y + BABY_HEIGHT / 2)
        {
            if(clampPosition.x > babyPosition.x - BABY_WIDTH / 2 && clampPosition.x < babyPosition.x + BABY_WIDTH / 2)
            {
                var threadPosition = thread.transform.position;
                threadPosition.x = babyPosition.x;
                thread.transform.position = threadPosition;

                BabyCollide();
            }
        }
    }

    private void BabyCollide()
    {
        var babyTransform = baby.transform;
        babyTransform.SetParent(clamp.transform, true);

        babyGrabbed = true;
        baby.SetSprite("grabbed");
        SetModeGrab();
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

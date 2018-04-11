using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutut : MonoBehaviour {

    private const float TRIGGER_DISTANCE = 30f;
    private const float RELEASED_SPEED = 14f;
    private const float DISTANCE_MULTIPLIER = 1f;

    private const float GRAVITY = 200f;
    private const float FALL_DISTANCE = 200f;

    private float startingY;
    private float lastY;

    private float speed = 0;
    private int remainingBounces = 3;
    private bool alreadyFell = false;
    private bool alreadyTriggered = false;

    [SerializeField] GameObject armController;
    [SerializeField] Arm arm;

    private Action doAction;
	// Use this for initialization
	void Start () {
        doAction = DoActionVoid;
	}
	
	// Update is called once per frame
	void Update () {
        doAction();
	}

    public void BeginGrab()
    {
        var mousePosition = Input.mousePosition;
        lastY = mousePosition.y;
        startingY = transform.position.y;
        doAction = DoActionGrabbed;
    }

    public void BeginEntrance()
    {
        if (!alreadyFell)
        {
            startingY = transform.position.y;
            doAction = DoActionFall;
            alreadyFell = true;
        }
    }

    private void DoActionFall()
    {
        var position = transform.position;
        position.y -= speed * Time.deltaTime;
        speed += GRAVITY * Time.deltaTime;
        if(position.y < startingY - FALL_DISTANCE)
        {
            position.y = startingY - FALL_DISTANCE;
            Bounce();
        }
        transform.position = position;
    }

    private void Bounce()
    {
        if(remainingBounces > 0)
        {
            remainingBounces--;
            speed = -(speed / 2);
        }
        else
        {
            doAction = DoActionVoid;
        }
        
    }

    private void DoActionGrabbed()
    {
        var mousePosition = Input.mousePosition;
        var position = transform.position;
        position.y += (mousePosition.y - lastY) * DISTANCE_MULTIPLIER;

        lastY = mousePosition.y;

        if (position.y > startingY) position.y = startingY;
        if (position.y < startingY - TRIGGER_DISTANCE)
        {
            position.y = startingY - TRIGGER_DISTANCE;
            Triggered();
        }
        transform.position = position;

        if(Input.GetMouseButtonUp(0))
        {
            EndGrab();
        }

    }

    private void Triggered()
    {
        if (!alreadyTriggered)
        {
            armController.SetActive(true);
            arm.StartEntrance();
            alreadyTriggered = true;
            EndGrab();
        }
    }

    private void EndGrab()
    {
        doAction = DoActionReleased;
    }

    private void DoActionReleased()
    {
        var position = transform.position;
        position.y += RELEASED_SPEED * Time.deltaTime;
        if(position.y > startingY)
        {
            position.y = startingY;
            doAction = DoActionVoid;
        }
        transform.position = position;
    }

    private void DoActionVoid()
    {

    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingCanon : MonoBehaviour {

    private const float ANGLE_PER_SEC = 45f;

    private float angleDest = 0;

    private Action doAction;

	// Use this for initialization
	void Start () {
        doAction = DoActionVoid;
    }
	
	// Update is called once per frame
	void Update () {
        doAction();
	}

    public void SetDestination (string direction)
    {
        if (direction == "left") angleDest = -90;
        else if (direction == "right") angleDest = 90;
        else if (direction == "bottom") angleDest = 0;
        SetModeMove();
    }

    private void SetModeMove()
    {
        float angle = transform.eulerAngles.z;
        if (angle > 180) angle -= 360;
        if(angle < angleDest)
        {
            doAction = DoActionRight;
        } else if (angle > angleDest)
        {
            doAction = DoActionLeft;
        }
    }

    private void DoActionRight()
    {
        float angle = transform.eulerAngles.z;
        if (angle > 180) angle -= 360;
        if(angle < angleDest)
        {
            transform.eulerAngles = Vector3.forward * (angle + ANGLE_PER_SEC * Time.deltaTime);
        } else if (angle >= angleDest)
        {
            transform.eulerAngles = Vector3.forward * (angleDest);
            SetModeVoid();
            
        }
    }

    private void DoActionLeft()
    {
        float angle = transform.eulerAngles.z;
        if(angle > 180) angle -=360;
        if(angle > angleDest)
        {
            transform.eulerAngles = Vector3.forward * (angle - ANGLE_PER_SEC * Time.deltaTime);
        } else if (angle <= angleDest)
        {
            transform.eulerAngles = Vector3.forward * (angleDest);
            SetModeVoid();
        }

    }

    private void SetModeVoid()
    {
        doAction = DoActionVoid;
    }

    private void DoActionVoid ()
    {

    }
}

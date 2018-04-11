using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GatlingJoystick : MonoBehaviour, IPointerDownHandler
{

    private const float TRIGGER_DISTANCE = 15f;

    private float startingX;
    private float startingY;

    [SerializeField] GatlingCanon gatlingCanon;

    private Action doAction;
	// Use this for initialization
	void Start()
   {
       doAction = DoActionVoid;
          }
	
	// Update is called once per frame
	void Update()
   {
       doAction();
          }

    private void DoActionVoid()
    {

    }
    
    private void DoActionGrabbed()
    {
        var position = Input.mousePosition;
        if(position.x<startingX - TRIGGER_DISTANCE)
        {
            ToLeft();
            StopGrab();
        } else if (position.x > startingX + TRIGGER_DISTANCE)
        {
            ToRight();
            StopGrab();
        }else if (position.y<startingY - TRIGGER_DISTANCE)
        {
            ToBottom();
            StopGrab();
        }

        if(Input.GetMouseButtonUp(0))
        {
            StopGrab();
        }
    }

    private void StopGrab()
    {
        doAction = DoActionVoid;
    }

    private void ToLeft()
    {
        gatlingCanon.SetDestination("left");
    }

    private void ToRight()
    {
        gatlingCanon.SetDestination("right");
    }

    private void ToBottom()
    {
        gatlingCanon.SetDestination("bottom");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var position = Input.mousePosition;
        startingX = position.x;
        startingY = position.y;
        doAction = DoActionGrabbed;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransistorButton : MonoBehaviour, IPointerDownHandler {
 
    private const int MAX_POWER = 90;
    private const float STARTING_ANGLE = 45;

    private const float DISTANCE_MULTIPLIER = 1f;

    private float power = 0;
    private float lastX;

    private Action doAction;

    // Use this for initialization
    void Start () {
        doAction = DoActionVoid;
	}
	
	// Update is called once per frame
	void Update () {
        doAction();
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        lastX = Input.mousePosition.x;
        doAction = DoActionGrabbed;
    }

    private void DoActionVoid ()
    {
    }

    private void DoActionGrabbed ()
    {
        var currentX = Input.mousePosition.x;
        power += (currentX - lastX) * DISTANCE_MULTIPLIER;
        if (power < 0) power = 0;
        else if (power >= MAX_POWER) power = MAX_POWER;
        lastX = currentX;
        UpdateDisplay();
        if (Input.GetMouseButtonUp(0)) {
            doAction = DoActionVoid;
        }
    }

    private void UpdateDisplay ()
    {
        float angle = STARTING_ANGLE - power;
        transform.eulerAngles = Vector3.forward * angle;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransistorButton : MonoBehaviour, IPointerDownHandler {
 
    //private const int MAX_POWER = 90;

    private const float ANGLE_MULTIPLIER = 0.5f;

    private float angle = 0;
    private float lastAngle;

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
        lastAngle = AngleTo(Input.mousePosition, transform.position);
        doAction = DoActionGrabbed;
    }

    private void DoActionVoid ()
    {
    }

    private void DoActionGrabbed ()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 buttonPosition = transform.position;
        float currentAngle = AngleTo(mousePosition, buttonPosition);
        
        if (Mathf.Abs(currentAngle - lastAngle) > 180)
        {
            float angleDistance;
            angleDistance = currentAngle - lastAngle;
            if (angleDistance < -180) angleDistance += 360;
            else if (angleDistance > 180) angleDistance -= 360;
            angle += (angleDistance) * ANGLE_MULTIPLIER;
        }
        else
        {
            angle += (currentAngle - lastAngle) * ANGLE_MULTIPLIER;
        }
        lastAngle = currentAngle;
        UpdateDisplay();
        if (Input.GetMouseButtonUp(0)) {
            doAction = DoActionVoid;
        }
    }

    private void UpdateDisplay ()
    {
        float neededAngle = angle;
        transform.eulerAngles = Vector3.forward * neededAngle;
    }

    private float AngleTo (Vector3 mousePosition, Vector3 buttonPosition)
    {
        return Mathf.Atan2(mousePosition.y - buttonPosition.y, mousePosition.x - buttonPosition.x) * Mathf.Rad2Deg;
    }
}

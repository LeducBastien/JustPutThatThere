using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baby : MonoBehaviour {

    private const float FALL_SPEED = 10f;
    private const float FALL_DISTANCE = 30f;

    private float startingY;

    private Action doAction;

    private Image image;

    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite fallSprite;
    [SerializeField] Sprite outSprite;
    [SerializeField] Sprite grabbedSprite;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        doAction = DoActionVoid;
    }
	
	// Update is called once per frame
	void Update () {
        if (Arm.Instance.babyGrabbed)
        {
            transform.position = Arm.Instance.clamp.transform.position + Vector3.up * -150;
        }
        else
            doAction();
        

	}

    public void SetSprite(string state)
    {
        if (state == "idle") image.sprite = idleSprite;
        if (state == "fall") image.sprite = fallSprite;
        if (state == "out") image.sprite = outSprite;
        if (state == "grabbed") image.sprite = grabbedSprite;
        
    }

    public void SetModeFall()
    {
        startingY = transform.position.y;
        SetSprite("fall");
        doAction = DoActionFall;
    }

    private void DoActionFall()
    {
        var position = transform.position;
        position.y -= FALL_SPEED * Time.deltaTime;
        if(position.y < startingY - FALL_DISTANCE)
        {
            position.y = startingY - FALL_DISTANCE;
            doAction = DoActionVoid;
        }
        transform.position = position;
    }

    private void DoActionVoid()
    {

    }

}

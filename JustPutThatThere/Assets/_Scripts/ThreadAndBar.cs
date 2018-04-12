using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadAndBar : MonoBehaviour {

    private const float GRAVITY = 200f;
    private const float FALL_DISTANCE = 150f;


    private const float MAX_ANGLE = 70f;
    private const float FLY_SPEED = 140f;

    private float startingY;

    private float speed = 0;
    private int remainingBounces = 3;
    private bool alreadyFell = false;
    private bool flying = false;

    [SerializeField] GameObject thread;
    [SerializeField] GameObject transistorButton;
    [SerializeField] Clamp clamp;
    [SerializeField] Animator lollipopAnimator;
    [SerializeField] GameObject diagButton;

    private Action doAction;
    // Use this for initialization
    void Start () {
        doAction = DoActionVoid;
	}

    // Update is called once per frame
    void Update()
    {
        doAction();
    }

    public void StartEntrance()
    {
        if (!alreadyFell)
        {
            startingY = transform.position.y;
            doAction = DoActionFall;
        }
    }

    public void FiredOn()
    {
        if(!flying && alreadyFell)
        {
            flying = true;
            doAction = DoActionFly;
        }
    }

    private void DoActionFly()
    {
        var angles = thread.transform.eulerAngles;
        angles.z += FLY_SPEED * Time.deltaTime;
        
        if (angles.z > MAX_ANGLE)
        {
            angles.z = MAX_ANGLE;
            TouchTop();
        }

        thread.transform.eulerAngles = angles;
    }

    private void TouchTop()
    {
        if(GameManager.Instance.roomButtonHere)
        {
            GameManager.Instance.lollipopActivated = true;
            //clamp.StartEntrance();
            //transistorButton.SetActive(true);
            lollipopAnimator.SetBool("TRUE", true);
            diagButton.SetActive(false);
        }
        doAction = DoActionComeBack;
    }

    private void DoActionComeBack()
    {
        var angles = thread.transform.eulerAngles;
        angles.z -= FLY_SPEED * Time.deltaTime;

        if (angles.z > 180)
        {
            angles.z = 0;
            doAction = DoActionVoid;
            flying = false;
        }

        thread.transform.eulerAngles = angles;
    }

    private void DoActionFall()
    {
        var position = transform.position;
        position.y -= speed * Time.deltaTime;
        speed += GRAVITY * Time.deltaTime;
        if (position.y < startingY - FALL_DISTANCE)
        {
            position.y = startingY - FALL_DISTANCE;
            Bounce();
        }
        transform.position = position;
    }

    private void Bounce()
    {
        if (remainingBounces > 0)
        {
            remainingBounces--;
            speed = -(speed / 2);
        }
        else
        {
            alreadyFell = true;
            doAction = DoActionVoid;
        }
    }

        

    private void DoActionVoid()
    {

    }
}

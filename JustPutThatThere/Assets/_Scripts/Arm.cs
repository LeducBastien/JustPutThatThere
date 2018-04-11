using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {

    private const float DOWN_SPEED = 30f;

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

    public void Descend()
    {
        doAction = DoActionGoDown;
    }

    private void DoActionGoDown()
    {
        var position = thread.transform.position;
        position.y -= DOWN_SPEED * Time.deltaTime;
        thread.transform.position = position;
    }

    private void DoActionVoid()
    {

    }
}

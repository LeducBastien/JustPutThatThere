﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopButton : MonoBehaviour {

    [SerializeField] GameObject lollipop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        GameManager.Instance.lollipopHere = true;
        lollipop.SetActive(true);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TututHandle : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] Tutut tutut;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        tutut.BeginGrab();
    }
}

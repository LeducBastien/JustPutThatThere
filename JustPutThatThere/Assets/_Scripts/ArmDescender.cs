using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmDescender : MonoBehaviour {

    [SerializeField] Arm arm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked ()
    {
        arm.Descend();
    }
}

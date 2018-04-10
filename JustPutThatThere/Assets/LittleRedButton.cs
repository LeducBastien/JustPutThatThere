using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedButton : MonoBehaviour {

    [SerializeField] GameObject lollipopButton;

    public void SpawnLollipopButton ()
    {
        lollipopButton.SetActive(true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

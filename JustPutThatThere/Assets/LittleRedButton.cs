using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedButton : MonoBehaviour {

    [SerializeField] GameObject bigRedButton;

    public void SpawnBigRedButton ()
    {
        bigRedButton.SetActive(true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

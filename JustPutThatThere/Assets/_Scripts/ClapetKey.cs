using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapetKey : MonoBehaviour {

    [SerializeField] GatlingDoor gatlingDoor;
    [SerializeField] GameObject gatlingController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        if(!GameManager.Instance.gatlingDoorOpen)
        {
            GameManager.Instance.gatlingDoorOpen = true;
            //gatlingDoor.Open();
        }

        gatlingController.SetActive(true);
    }
}

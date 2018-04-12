using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClapetKey : MonoBehaviour {

    [SerializeField] GatlingDoor gatlingDoor;
    [SerializeField] GameObject gatlingController;
    private Image image;
    [SerializeField] Sprite onSprite;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        if(!GameManager.Instance.gatlingDoorOpen)
        {
            GameManager.Instance.gatlingDoorOpen = true;
            gatlingDoor.enabled = true;
        }

        gatlingController.SetActive(true);
        image.sprite = onSprite;

    }
}

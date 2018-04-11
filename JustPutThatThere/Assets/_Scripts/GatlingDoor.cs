using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingDoor : MonoBehaviour {

    [SerializeField] Sprite openSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open()
    {
        GetComponent<SpriteRenderer>().sprite = openSprite;
    }
}

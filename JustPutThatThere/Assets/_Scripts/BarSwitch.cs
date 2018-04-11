using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSwitch : MonoBehaviour {

    //[SerializeField] Bar bar;
    [SerializeField] Sprite onSprite;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        GameManager.Instance.barFell = true;
        GetComponent<SpriteRenderer>().sprite = onSprite;
    }
}

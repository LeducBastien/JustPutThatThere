using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarSwitch : MonoBehaviour {

    [SerializeField] ThreadAndBar threadAndBar;
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
        GetComponent<Image>().sprite = onSprite;

        threadAndBar.StartEntrance();
    }
}

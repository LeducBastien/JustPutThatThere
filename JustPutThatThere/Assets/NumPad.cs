using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour {

    private string value;

    private readonly List<string> codes = new List<string>();


    [SerializeField] Text display;

    NumPad()
    {
        codes.Add("34");
        codes.Add("996678");
    }

    public void Reset()
    {
        value = "";
        display.text = value;
    }

    public void ButtonPressed (string digit)
    {
        value += digit;
        display.text = value;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

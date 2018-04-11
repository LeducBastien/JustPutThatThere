using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour {

    private const int MAX_CHARACTERS = 6;

    private string value;

    private readonly List<string> codes = new List<string>();
    private readonly List<Action> actions = new List<Action>();


    [SerializeField] Text display;
    [SerializeField] GameObject bigRedButton;
    [SerializeField] GatlingBase gatlingBase;

    NumPad()
    {
        codes.Add("80085");
        actions.Add(UnlockCeilingTrap);

        codes.Add("996678");
        actions.Add(UnlockMachinegun);

        codes.Add("666");
        actions.Add(UnlockBigRedButton);

        value = "";
    }

    public void Reset()
    {
        value = "";
        display.text = value;
    }

    public void ButtonPressed (string digit)
    {
        if (value.Length < MAX_CHARACTERS)
        {
            value += digit;
            display.text = value;
            CompareCodes();
        }
    }

    private void CompareCodes ()
    {
        for(var i = 0; i < codes.Count; i++)
        {
            if(codes[i] == value)
            {
                actions[i]();
                Reset();
            }
        }
    }

    private void UnlockMachinegun ()
    {
        if(GameManager.Instance.gatlingDoorOpen)
        {
            gatlingBase.StartEntrance();
        }
    }

    private void UnlockCeilingTrap ()
    {
        print("unlocking trap");
    }

    private void UnlockBigRedButton ()
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

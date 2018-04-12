using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumPad : MonoBehaviour {

    private const int MAX_CHARACTERS = 6;

    private string value;

    private readonly List<string> codes = new List<string>();
    private readonly List<Action> actions = new List<Action>();

    AudioSource devilAudio;
    AudioSource boobsAudio;

    [SerializeField] TextMeshProUGUI display;
    [SerializeField] GameObject bigRedButton;
    [SerializeField] GatlingBase gatlingBase;
    [SerializeField] GameObject simonInstance;

    NumPad()
    {
        codes.Add("80085");
        actions.Add(UnlockSimonGame);

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

    private void UnlockSimonGame ()
    {
        GameManager.Instance.roomButtonHere = true;
        boobsAudio.Play();
        simonInstance.SetActive(true);
    }

    private void UnlockBigRedButton ()
    {
        bigRedButton.SetActive(true);
        devilAudio.Play();
    }

    // Use this for initialization
    void Start () {
        devilAudio = GetComponents<AudioSource>()[0];
        boobsAudio = GetComponents<AudioSource>()[1];


    }

    // Update is called once per frame
    void Update () {
		
	}
}

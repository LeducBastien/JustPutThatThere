using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField] GameObject helpButtonInstance;
    [SerializeField] float timeBeforeHelp;
    private float timer = 0;
    public bool pustuleButtonActivated = false;
    public bool gameOver = false;



    private void Awake()
    {
        if (Instance) return;
        Instance = this;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBeforeHelp)
            helpButtonInstance.SetActive(true);
    }

}

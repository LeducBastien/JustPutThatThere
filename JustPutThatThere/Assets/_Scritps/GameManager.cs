using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public bool pustuleButtonActivated = false;
    public bool gameOver = false;

    private void Awake()
    {
        if (Instance) return;
        Instance = this;
    }

}

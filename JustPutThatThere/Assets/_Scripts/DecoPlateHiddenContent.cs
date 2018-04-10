using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoPlateHiddenContent : MonoBehaviour {

    [SerializeField] GameObject arcadeButtonInstance;

    public void OnClicked()
    {
        arcadeButtonInstance.SetActive(true);
    }
}

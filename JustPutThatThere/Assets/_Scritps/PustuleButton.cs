using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PustuleButton : MonoBehaviour {

    [SerializeField] List<Transform> spawnPoint;
    [SerializeField] GameObject pustuleButtonPrefab;

    private void Start()
    {
        SpawnPustuleButton();
    }

    public void SpawnPustuleButton()
    {
        GameObject pustuleButtonInstance = Instantiate(pustuleButtonPrefab);
        int randomSpawn = Random.Range(0, spawnPoint.Count);
        pustuleButtonInstance.transform.position = spawnPoint[randomSpawn].position;
        GameManager.Instance.pustuleButtonActivated = true;
    }

}

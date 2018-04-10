using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTrapOpener : MonoBehaviour {
    [SerializeField] GameObject TriggerInstance;
    [SerializeField] GameObject MachineGunDoorInstance;

    public void OpenMachineGunDoor()
    {
    }

    public void ShowTrigger()
    {
        TriggerInstance.SetActive(true);
    }

}

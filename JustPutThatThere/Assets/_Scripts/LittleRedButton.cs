using UnityEngine;


public class LittleRedButton : MonoBehaviour
{

    [SerializeField] GameObject lollipopButton;

    public void SpawnLollipopButton()
    {
        lollipopButton.SetActive(true);
    }
}

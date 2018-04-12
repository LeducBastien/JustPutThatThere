using UnityEngine;


public class LittleRedButton : MonoBehaviour
{

    [SerializeField] GameObject lollipopButton;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SpawnLollipopButton()
    {
        lollipopButton.SetActive(true);
        audioSource.Play();
    }
}

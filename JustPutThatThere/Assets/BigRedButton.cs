using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BigRedButton : MonoBehaviour {

    [SerializeField] Image blackScreen;

    AudioSource bigRedButtonAudioSource;
    AudioSource shutdownAudioSource;

    bool shutdowned = false;

    private void Start()
    {
        bigRedButtonAudioSource = GetComponents<AudioSource>()[0];
        shutdownAudioSource = GetComponents<AudioSource>()[1];
    }

    public void OnClick()
    {
        blackScreen.DOFade(1f, 1f).SetEase(Ease.InBounce);
        bigRedButtonAudioSource.Play();
        StartCoroutine(DoEffect());
    }

    IEnumerator DoEffect()
    {
        if (shutdowned) StopCoroutine(DoEffect());
        shutdowned = true;
        shutdownAudioSource.Play();

        while (shutdownAudioSource.pitch > 0)
        {
            shutdownAudioSource.pitch -= Time.deltaTime / 2;
            yield return null;
        }
    }
}

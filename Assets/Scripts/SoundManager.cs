using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioClip goldSound, winSound, loseSound;

    [Header("Audio Source")]
    [SerializeField] AudioSource audioSrc;

    [Header("Mixers")]
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioMixer soundsMixer;

    private void Awake() {
        if(instance == null) {
            instance = this;
		} else {
            Destroy(gameObject);
		}
        DontDestroyOnLoad(this);
    }

    void Start() {
        musicMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Music"));
        soundsMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Sound"));
    }


    public void PlaySound(string clip) {
        switch (clip) {
            case "gold":
                audioSrc.PlayOneShot(goldSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            case "lose":
                audioSrc.PlayOneShot(loseSound);
                break;
        }
    }

    public void StopSound() {
        audioSrc.Stop();
    }
}

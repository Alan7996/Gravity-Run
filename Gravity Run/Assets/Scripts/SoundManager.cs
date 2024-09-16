using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<SoundManager>();
            }
            return s_instance;
        }
    }

    private static SoundManager s_instance;

    private AudioSource audioSource;
    
    public AudioClip bgm;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    private bool fadeToStop = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeToStop) return;

        if (audioSource.volume <= 0.01f) {
            audioSource.Stop();
            fadeToStop = false;
        } else {
            float newVolume = audioSource.volume - (0.02f * Time.deltaTime);
            if (newVolume < 0f)
            {
                newVolume = 0f;
            }
            audioSource.volume = newVolume;
        }
    }

    public void PlayJumpClip() {
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlayDead() {
        audioSource.PlayOneShot(deathClip);
        fadeToStop = true;
    }
}

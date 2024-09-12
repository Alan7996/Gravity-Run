using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private AudioSource audio;
    
    public AudioClip jumpClip;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpClip() {
        audio.PlayOneShot(jumpClip);
    }
}

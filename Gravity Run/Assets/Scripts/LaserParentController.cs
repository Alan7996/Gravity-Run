using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParentController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip laserVibration;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = laserVibration;
        audioSource.loop = true;
        audioSource.volume = 0f;
        audioSource.Play();

        transform.rotation = OctaCylinderContainerController.instance.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused) return;

        if (transform.position.x < 55f && transform.position.x > -5f)
            audioSource.volume = Math.Min(0.4f, 0.4f * (1f - (transform.position.x + 5f) / 60f));
        else if (transform.position.x < -5f) 
            audioSource.volume = Math.Max(0f, 0.4f * (25f + transform.position.x) / 20f);

        if (transform.position.x < -25.0f)
            Destroy(gameObject);
    }

    void FixedUpdate() {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused) return;

        transform.Translate(new Vector3(-GameManager.instance.laserSpeed * Time.deltaTime * 10.0f, 0.0f, 0.0f), Space.World);
    }
}

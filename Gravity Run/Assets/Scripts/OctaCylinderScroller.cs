using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaCylinderScroller : MonoBehaviour
{
    public List<GameObject> childLasers;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -50.0f)
        {
            transform.position = new Vector3(250.0f, 0.0f, 0.0f);
        }
    }

    void FixedUpdate() {
        if (GameManager.instance.isGamePaused) return;

        transform.Translate(new Vector3(-GameManager.instance.laserSpeed * Time.deltaTime * 10.0f, 0.0f, 0.0f), Space.World);
    }
}

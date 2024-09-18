using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;

    private float zCurrRot;
    private float zRotTarget = 0.0f;
    private float[] rotTargets;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        rotTargets = new[] { 0f, // placeholder
                             -45f,
                             0f, // down
                             45f,
                             -90f, // left
                             0f, // placeholder
                             90f, // right
                             -135f,
                             -180f, // up
                             135f,
                            };
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGamePaused) return;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, zRotTarget, ref zCurrRot, 0.5f);
        transform.rotation = Quaternion.Euler(0, 90, angle);
    }

    public void ChangeGravity(int gravityDir) {
        zRotTarget += rotTargets[gravityDir];
    }
}

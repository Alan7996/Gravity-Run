using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    public float jumpForce = 40.0f;

    private float xCurrRot;
    private float xRotTarget = 0.0f;
    private float[] rotTargets;

    private Vector3 downVector;
    private Vector3[] gravities;

    private bool isJumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        rotTargets = new[] { 0f, // placeholder
                             -45f,
                             0f, // down
                             45f,
                             -90f, // left
                             0f, // placeholder
                             90f, // right
                             45f, // should be -135f, but bugged
                             0f, // should be -180f, // up, but bugged
                             -45f, // should be 135f, but bugged
                            };

        gravities = new [] { new Vector3(0, 0, 0), // placeholder
                             new Vector3(0, -1, 1),
                             new Vector3(0, -1, 0), // down
                             new Vector3(0, -1, -1),
                             new Vector3(0, 0, 1), // left
                             new Vector3(0.0f, 0.0f, 0.0f), // placeholder
                             new Vector3(0, 0, -1), // right
                             new Vector3(0, 1, 1),
                             new Vector3(0, 1, 0), // up
                             new Vector3(0, 1, -1)
                            };

        for (int i = 0; i < gravities.Length; i++) {
            gravities[i] = gravities[i].normalized * 9.81f;
        }
        downVector = gravities[2];
        Physics.gravity = downVector;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.x, xRotTarget, ref xCurrRot, 0.5f);
        transform.rotation = Quaternion.Euler(angle, 0, 0);
    }

    public void Jump() {
        if (isJumping) return;
        isJumping = true;
        m_Rigidbody.AddForce(-downVector * jumpForce);
    }

    public void ChangeGravity(int gravityDir) {
        xRotTarget = rotTargets[gravityDir];
        downVector = gravities[gravityDir];
        Physics.gravity = downVector;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}

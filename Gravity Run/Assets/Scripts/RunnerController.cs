using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    public float jumpForce = 60.0f;

    private float xCurrRot;
    private float xRotTarget = 0.0f;
    private float[] rotTargets;

    private Vector3 downVector;

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
                             -135f,
                             -180f, // up
                             135f,
                            };

        Physics.gravity = 9.81f * (transform.rotation * Vector3.down);
        downVector = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        // don't need for now since we are using a sphere
        // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.x, xRotTarget, ref xCurrRot, 0.5f);
        // transform.rotation = Quaternion.Euler(angle, 0, 0);
    }

    public void Jump() {
        if (isJumping) return;
        isJumping = true;
        m_Rigidbody.AddForce(-downVector * jumpForce);
        SoundManager.instance.PlayJumpClip();
    }

    public void ChangeGravity(int gravityDir) {
        xRotTarget += rotTargets[gravityDir];
        transform.rotation = Quaternion.Euler(xRotTarget, 0, 0);
        downVector = 9.81f * (transform.rotation * Vector3.down);
        Physics.gravity = downVector;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        if (collision.gameObject.tag == "Laser") {
            gameObject.SetActive(false);
            GameManager.instance.Die();
        }
    }
}

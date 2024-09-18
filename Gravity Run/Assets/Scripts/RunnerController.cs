using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public static RunnerController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<RunnerController>();
            }
            return m_instance;
        }
    }

    private static RunnerController m_instance;

    private Rigidbody m_Rigidbody;

    public float jumpForce = 60.0f;

    private float xRotTarget = 0.0f;
    private float[] rotTargets;

    private Vector3 downVector;

    private Vector3 tempGravity;
    private Vector3 tempVelocity;

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

    public void PauseRunner(bool pausing) {
        if (pausing) {
            tempGravity = Physics.gravity;
            Physics.gravity = Vector3.zero;

            tempVelocity = m_Rigidbody.velocity;
            m_Rigidbody.velocity = Vector3.zero;
        } else {
            Physics.gravity = tempGravity;
            m_Rigidbody.velocity = tempVelocity;
        }
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

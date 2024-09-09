using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    public float jumpForce = 400.0f;

    private Vector3 upVector;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        upVector = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump() {
        if (isJumping) return;
        isJumping = true;
        m_Rigidbody.AddForce(upVector * jumpForce);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}

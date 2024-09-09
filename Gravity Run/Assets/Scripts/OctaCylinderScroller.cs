using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaCylinderScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -50.0f)
        {
            transform.position = new Vector3(250.0f, 0.0f, 0.0f);
        }
    }

    void FixedUpdate() {
        transform.Translate(new Vector3(-1 * Time.deltaTime * 10.0f, 0.0f, 0.0f), Space.World);
    }
}

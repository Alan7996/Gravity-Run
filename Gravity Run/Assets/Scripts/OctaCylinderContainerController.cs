using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaCylinderContainerController : MonoBehaviour
{
    public static OctaCylinderContainerController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<OctaCylinderContainerController>();
            }
            return m_instance;
        }
    }

    private static OctaCylinderContainerController m_instance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;
        
        transform.Rotate(Time.deltaTime * 5.0f, 0, 0);
    }
}

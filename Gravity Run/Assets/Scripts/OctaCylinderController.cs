using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaCylinderController : MonoBehaviour
{
    public static OctaCylinderController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<OctaCylinderController>();
            }
            return m_instance;
        }
    }

    private static OctaCylinderController m_instance;

    public Transform octaCylinderTransform1;
    public Transform octaCylinderTransform2;

    float rot;
    public float target = 22.5f;

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        octaCylinderTransform1.rotation = Quaternion.Euler(0, 90, target);
        octaCylinderTransform2.rotation = Quaternion.Euler(0, 90, target);
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.SmoothDampAngle(octaCylinderTransform1.eulerAngles.z, target, ref rot, 0.5f);
        octaCylinderTransform1.rotation = Quaternion.Euler(0, 90, angle);
        octaCylinderTransform2.rotation = Quaternion.Euler(0, 90, angle);
    }

    public void RotateOcta(int gravityDir) {
        target = target + gravityDir * 45.0f;
    }
}


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
}

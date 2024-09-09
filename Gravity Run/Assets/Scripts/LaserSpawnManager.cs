using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnManager : MonoBehaviour
{
    public static LaserSpawnManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<LaserSpawnManager>();
            }
            return m_instance;
        }
    }

    private static LaserSpawnManager m_instance;

    public GameObject octaCylinder1;
    public Transform octaCylinder1Transform;
    public GameObject octaCylinder2;
    public Transform octaCylinder2Transform;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn() {
        // spawn on the farther cylinder
        if (octaCylinder1Transform.position.x <= octaCylinder2Transform.position.x) {
            
        } else {
            
        }
    }
}

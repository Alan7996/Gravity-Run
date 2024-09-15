using System;
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

    public GameObject laserParent;
    public OctaCylinderScroller octaCylinder1;
    public Transform octaCylinder1Transform;
    public OctaCylinderScroller octaCylinder2;
    public Transform octaCylinder2Transform;

    /*
        1-3, 1-6, 1-7, 1-8, 1-9,
        2-4, 2-6, 2-7, 2-8, 2-9,
        3-4. 3-7. 3-8, 3-9, 4-6,
        4-8, 4-9, 6-7, 6-8, 7-9
    */
    private int[] laserConnections;
    public GameObject[] lasers;

    private int numSpawns = 0;
    private int numSpawnedLasers = 2;

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
        laserConnections = new [] { 13, 16, 17, 18, 19, 24, 26, 27, 28, 29, 34,
                                    37, 38, 39, 46, 48, 49, 67, 68, 79 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn() {
        numSpawns++;
        
        if (numSpawns / 5 - numSpawnedLasers == -1) numSpawnedLasers++;
        numSpawnedLasers = Math.Min(numSpawnedLasers, 6);
        
        // can and should simplify to just one loop
        // choose at least two safe spots
        int numSafeSpots = UnityEngine.Random.Range(2, 6);
        List<int> safeSpots = new List<int>();
        while (safeSpots.Count < numSafeSpots) {
            // consider 5~8 as 6~9
            int nextInd = UnityEngine.Random.Range(1, 9);
            while (true) {
                if (safeSpots.IndexOf(nextInd) == -1) {
                    break;
                }
                nextInd = UnityEngine.Random.Range(1, 9);
            }
            safeSpots.Add(nextInd);
        }

        Transform tempTransform;
        // choose all lasers that connect spawn points for now
        GameObject newParent = Instantiate(laserParent);
        GameObject newObject;

        List<int> laserObjectIndices = new List<int>();
        while (true) {
            int i = UnityEngine.Random.Range(0, 20);
            if (safeSpots.IndexOf(laserConnections[i] % 10) > -1 && safeSpots.IndexOf(laserConnections[i] / 10) > -1) {
                continue;
            }
            laserObjectIndices.Add(i);
            if (laserObjectIndices.Count >= numSpawnedLasers) break;
        }

        for (int i = 0; i < laserObjectIndices.Count; i++) {
            tempTransform = lasers[laserObjectIndices[i]].GetComponent<Transform>();
            newObject = Instantiate(lasers[laserObjectIndices[i]], new Vector3(200f, tempTransform.position.y, tempTransform.position.z), tempTransform.rotation);
            newObject.transform.parent = newParent.transform;
        }
    }

    public void IncNumSpawn() {
        numSpawns++;
    }

    public void DecNumSpawn() {
        numSpawns--;
    }
}

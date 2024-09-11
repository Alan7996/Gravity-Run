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
        int numLessSpawn = 4 < numSpawns / 10 ? 4 : numSpawns / 10;

        // can and should simplify to just one loop
        // choose at least two safe spots
        int numSafeSpots = UnityEngine.Random.Range(2, 6 - numLessSpawn);
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

        List<int> spawnSpots = new List<int>();
        for (int i = 1; i < 9; i++) {
            if (safeSpots.IndexOf(i) == -1) {
                if (i > 4)
                    spawnSpots.Add(i + 1);
                else   
                    spawnSpots.Add(i);
            }
        }

        Transform tempTransform;
        // choose all lasers that connect spawn points for now
        GameObject newParent = Instantiate(laserParent);
        GameObject newObject;
        for (int i = 0; i < 20; i++) {
            if (spawnSpots.IndexOf(laserConnections[i] % 10) > -1 && spawnSpots.IndexOf(laserConnections[i] / 10) > -1) {
                tempTransform = lasers[i].GetComponent<Transform>();
                newObject = Instantiate(lasers[i], new Vector3(200f, tempTransform.position.y, tempTransform.position.z), tempTransform.rotation);
                newObject.transform.parent = newParent.transform;
            }
        }
        
        // List<int> laserObjectIndices = new List<int>();
        // spawn on the farther cylinder
        // if (octaCylinder1Transform.position.x <= octaCylinder2Transform.position.x) {
        //     for (int i = 0; i < laserObjectIndices.Count; i++) {
        //         octaCylinder2.childLasers.Add(lasers[i]);
        //     }
        // } else {
        //     for (int i = 0; i < laserObjectIndices.Count; i++) {
        //         octaCylinder1.childLasers.Add(lasers[i]);
        //     }
        // }
    }
}

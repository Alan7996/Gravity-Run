using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParentController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = OctaCylinderContainerController.instance.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        if (transform.position.x < -5.0f)
            Destroy(gameObject);
    }

    void FixedUpdate() {
        if (GameManager.instance.isGameOver) return;

        transform.Translate(new Vector3(-GameManager.instance.laserSpeed * Time.deltaTime * 10.0f, 0.0f, 0.0f), Space.World);
    }
}

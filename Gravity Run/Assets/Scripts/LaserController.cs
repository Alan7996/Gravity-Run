using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private Material mat;
    private Color col;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        col = mat.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        col.a = (200f - transform.position.x + 10f) / 200f;
        mat.SetColor("_Color", col);
        if (transform.position.x < -5.0f)
            Destroy(gameObject);
    }
}
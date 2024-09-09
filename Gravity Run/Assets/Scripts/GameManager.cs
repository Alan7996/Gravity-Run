using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;

    public CameraController cam;
    public LaserSpawnManager laserSpawner;
    public OctaCylinderController octaCyl;
    public RunnerController runner;

    public TextMeshProUGUI textScore; 

    private float totalTimer = 0.0f;
    private float spawnTimer = 0.0f;
    private float spawnTime = 5.0f;

    public bool isGamePaused { get; private set; }
    public bool isGameOver { get; private set; }

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
        totalTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime) {
            spawnTimer -= spawnTime;
            laserSpawner.Spawn();

            // update spawnTime
            if (spawnTime > 1.0f)
                spawnTime -= 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
            octaCyl.RotateOcta(1);
        else if (Input.GetKeyDown(KeyCode.Keypad4))
            octaCyl.RotateOcta(2);
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            octaCyl.RotateOcta(3);
        else if (Input.GetKeyDown(KeyCode.Keypad8))
            octaCyl.RotateOcta(4);
        else if (Input.GetKeyDown(KeyCode.Keypad9))
            octaCyl.RotateOcta(-3);
        else if (Input.GetKeyDown(KeyCode.Keypad6))
            octaCyl.RotateOcta(-2);
        else if (Input.GetKeyDown(KeyCode.Keypad3))
            octaCyl.RotateOcta(-1);
        else if (Input.GetKeyDown(KeyCode.Keypad5))
            runner.Jump();
    }

    public void ChangeDirection(int dir) {
        cam.ChangeDirection(dir);
    }

    public void GameStart() {
        SceneManager.LoadScene(1);
    }

    public void GameReturn() {
        SceneManager.LoadScene(0);
    }

    public void GameExit() {
        Application.Quit();
    }
}

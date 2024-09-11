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
    public RunnerController runner;

    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textGameOverScore;
    public GameObject newHighscore;
    public GameObject gameOverCanvas;

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
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            isGameOver = true;
        }
        if (gameOverCanvas)
            gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        
        totalTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime) {
            spawnTimer -= spawnTime;
            laserSpawner.Spawn();

            // update spawnTime
            if (spawnTime > 1.0f)
                spawnTime -= 0.1f;
        }

        if (textScore)
            textScore.text = totalTimer.ToString("0.0");

        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            runner.ChangeGravity(1);
        } else if (Input.GetKeyDown(KeyCode.Keypad4)) {
            runner.ChangeGravity(4);
        } else if (Input.GetKeyDown(KeyCode.Keypad7)) {
            runner.ChangeGravity(7);
        } else if (Input.GetKeyDown(KeyCode.Keypad8)) {
            runner.ChangeGravity(8);
        } else if (Input.GetKeyDown(KeyCode.Keypad9)) {
            runner.ChangeGravity(9);
        } else if (Input.GetKeyDown(KeyCode.Keypad6)) {
            runner.ChangeGravity(6);
        } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
            runner.ChangeGravity(3);
        } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
            runner.ChangeGravity(2);
        } else if (Input.GetKeyDown(KeyCode.Keypad5))
            runner.Jump();
    }

    public void Die() {
        isGameOver = true;
        textScore.text = "";
        textGameOverScore.text = totalTimer.ToString("0.0");

        float highscore = PlayerPrefs.GetFloat("Highscore");
        if (highscore < totalTimer) {
            PlayerPrefs.SetFloat("Highscore", totalTimer);
            newHighscore.SetActive(true);
        } else {
            newHighscore.SetActive(false);
        }
        gameOverCanvas.SetActive(true);
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

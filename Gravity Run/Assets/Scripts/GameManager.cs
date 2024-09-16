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

    public const bool PLAYTEST = true;

    public CameraController cam;
    public LaserSpawnManager laserSpawner;
    public RunnerController runner;

    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textGameOverScore;
    public GameObject newHighscore;
    public GameObject gameOverCanvas;
    public GameObject controlUI;

    private float totalTimer = 0.0f;
    private float spawnTimer = 0.0f;
    private float spawnTime = 4.0f;

    public float laserSpeed = 2.0f;

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
        if (controlUI)
            controlUI.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.V)) {
            ChangeGravity(1);
        } else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.F)) {
            ChangeGravity(4);
        } else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.R)) {
            ChangeGravity(7);
        } else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.T)) {
            ChangeGravity(8);
        } else if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Y)) {
            ChangeGravity(9);
        } else if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.H)) {
            ChangeGravity(6);
        } else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.N)) {
            ChangeGravity(3);
        } else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.V)) {
            ChangeGravity(2);
        } else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.G))
            runner.Jump();

        if (PLAYTEST) {
            // for play testing
            if (Input.GetKeyDown(KeyCode.Q)) {
                // spawn later
                spawnTimer -= 0.5f;
            } else if (Input.GetKeyDown(KeyCode.W)) {
                // spawn faster
                spawnTimer += 0.5f;
            } else if (Input.GetKeyDown(KeyCode.A)) {
                // decrement number of lasers spawned so far
                laserSpawner.DecNumSpawn();
            } else if (Input.GetKeyDown(KeyCode.S)) {
                // increment number of lasers spawned so far
                laserSpawner.IncNumSpawn();
            } else if (Input.GetKeyDown(KeyCode.Z)) {
                // decrease incoming speed
                laserSpeed -= 0.5f;
            } else if (Input.GetKeyDown(KeyCode.X)) {
                // increase incoming speed
                laserSpeed += 0.5f;
            }
        }
    }

    void ChangeGravity(int gravityDir) {
        runner.ChangeGravity(gravityDir);
        cam.ChangeGravity(gravityDir);
    }

    public void Die() {
        isGameOver = true;
        textScore.text = "";
        textGameOverScore.text = totalTimer.ToString("0.0");
        
        controlUI.SetActive(false);

        float highscore = PlayerPrefs.GetFloat("Highscore");
        if (highscore < totalTimer) {
            PlayerPrefs.SetFloat("Highscore", totalTimer);
            newHighscore.SetActive(true);
        } else {
            newHighscore.SetActive(false);
        }
        gameOverCanvas.SetActive(true);

        SoundManager.instance.PlayDead();
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

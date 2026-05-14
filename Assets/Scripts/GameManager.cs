using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Powerups")]
    [SerializeField] private int speedBoostCost = 10;
    [SerializeField] private float speedBoostAmount = 8f;
    [SerializeField] private float speedBoostDuration = 5f;

    private bool isSpeedBoostActive;
    private float speedBoostTimer;

    [SerializeField] private GameConfig config;

    public float ScrollSpeed { get; private set; }
    public float Distance { get; private set; }

    public int RunCoins { get; private set; }
    public int TotalCoins { get; private set; }

    public bool IsGameOver { get; private set; }

    public int HighScore { get; private set; }

    void Awake()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        ScrollSpeed = config.startSpeed;
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (IsGameOver)
        {
            if (Keyboard.current != null &&
                Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex
                );
            }

            return;
        }

        if (Keyboard.current != null &&
            Keyboard.current.bKey.wasPressedThisFrame)
        {
            ActivateSpeedBoost();
        }

        float targetMaxSpeed =
            isSpeedBoostActive
            ? config.maxSpeed + speedBoostAmount
            : config.maxSpeed;

        ScrollSpeed = Mathf.Min(
            ScrollSpeed + config.speedIncreaseRate * Time.deltaTime,
            targetMaxSpeed
        );

        Distance += ScrollSpeed * Time.deltaTime;

        if (isSpeedBoostActive)
        {
            speedBoostTimer -= Time.deltaTime;

            if (speedBoostTimer <= 0f)
            {
                isSpeedBoostActive = false;

                ScrollSpeed = Mathf.Min(
                    ScrollSpeed,
                    config.maxSpeed
                );

                Debug.Log("Speed Boost ended.");
            }
        }
    }

    public void ActivateSpeedBoost()
    {
        if (isSpeedBoostActive) return;

        if (TotalCoins < speedBoostCost)
        {
            Debug.Log("Not enough coins for speed boost.");
            return;
        }

        TotalCoins -= speedBoostCost;

        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        PlayerPrefs.Save();

        isSpeedBoostActive = true;
        speedBoostTimer = speedBoostDuration;

        ScrollSpeed += speedBoostAmount;

        Debug.Log("Speed Boost activated!");
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        ScrollSpeed = 0f;

        int currentScore = Mathf.FloorToInt(Distance);

        if (currentScore > HighScore)
        {
            HighScore = currentScore;

            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();

            Debug.Log("New High Score: " + HighScore);
        }

        Debug.Log(
            "Game Over! Final Score: " +
            Mathf.FloorToInt(Distance)
        );
    }

    public void AddCoin()
    {
        RunCoins++;
        TotalCoins++;

        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        PlayerPrefs.Save();

        Debug.Log(
            "Run Coins: " + RunCoins +
            " | Total Coins: " + TotalCoins
        );
    }
}
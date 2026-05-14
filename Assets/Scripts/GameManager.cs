using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameConfig config;

    [Header("Speed Boost Powerup")]
    [SerializeField] private int speedBoostCost = 10;
    [SerializeField] private float speedBoostAmount = 8f;
    [SerializeField] private float speedBoostDuration = 5f;

    private bool isSpeedBoostActive;
    private float speedBoostTimer;

    [Header("Magnet Powerup")]
    [SerializeField] private int magnetCost = 15;
    [SerializeField] private float magnetDuration = 6f;
    [SerializeField] private float magnetRadius = 6f;
    [SerializeField] private float magnetPullSpeed = 12f;

    private bool isMagnetActive;
    private float magnetTimer;

    [Header("Invincibility Powerup")]
    [SerializeField] private int invincibilityCost = 20;
    [SerializeField] private float invincibilityDuration = 5f;

    private bool isInvincible;
    private float invincibilityTimer;

    public bool IsInvincible => isInvincible;

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

        if (Keyboard.current != null &&
            Keyboard.current.mKey.wasPressedThisFrame)
        {
            ActivateMagnet();
        }

        if (Keyboard.current != null &&
            Keyboard.current.iKey.wasPressedThisFrame)
        {
            ActivateInvincibility();
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

        UpdateSpeedBoost();
        UpdateMagnet();
        UpdateInvincibility();
    }

    private void UpdateSpeedBoost()
    {
        if (!isSpeedBoostActive) return;

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

    private void UpdateMagnet()
    {
        if (!isMagnetActive) return;

        magnetTimer -= Time.deltaTime;

        PullCoinsToPlayer();

        if (magnetTimer <= 0f)
        {
            isMagnetActive = false;
            Debug.Log("Magnet ended.");
        }
    }

    private void UpdateInvincibility()
    {
        if (!isInvincible) return;

        invincibilityTimer -= Time.deltaTime;

        if (invincibilityTimer <= 0f)
        {
            isInvincible = false;
            Debug.Log("Invincibility ended.");
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
        SaveTotalCoins();

        isSpeedBoostActive = true;
        speedBoostTimer = speedBoostDuration;

        ScrollSpeed += speedBoostAmount;

        Debug.Log("Speed Boost activated!");
    }

    public void ActivateMagnet()
    {
        if (isMagnetActive) return;

        if (TotalCoins < magnetCost)
        {
            Debug.Log("Not enough coins for magnet.");
            return;
        }

        TotalCoins -= magnetCost;
        SaveTotalCoins();

        isMagnetActive = true;
        magnetTimer = magnetDuration;

        Debug.Log("Magnet activated!");
    }

    public void ActivateInvincibility()
    {
        if (isInvincible) return;

        if (TotalCoins < invincibilityCost)
        {
            Debug.Log("Not enough coins for invincibility.");
            return;
        }

        TotalCoins -= invincibilityCost;
        SaveTotalCoins();

        isInvincible = true;
        invincibilityTimer = invincibilityDuration;

        Debug.Log("Invincibility activated!");
    }

    private void PullCoinsToPlayer()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        Collider[] colliders = Physics.OverlapSphere(
            player.transform.position,
            magnetRadius
        );

        foreach (Collider col in colliders)
        {
            if (!col.CompareTag("Coin")) continue;

            col.transform.position = Vector3.MoveTowards(
                col.transform.position,
                player.transform.position,
                magnetPullSpeed * Time.deltaTime
            );
        }
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        if (isInvincible)
        {
            Debug.Log("Game over ignored because player is invincible.");
            return;
        }

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

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void AddCoin()
    {
        RunCoins++;
        TotalCoins++;

        SaveTotalCoins();

        Debug.Log(
            "Run Coins: " + RunCoins +
            " | Total Coins: " + TotalCoins
        );
    }

    private void SaveTotalCoins()
    {
        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        PlayerPrefs.Save();
    }
}
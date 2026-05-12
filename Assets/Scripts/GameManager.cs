using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameConfig config;

    public float ScrollSpeed { get; private set; }
    public float Distance { get; private set; }
    public bool IsGameOver { get; private set; }
public int HighScore { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        ScrollSpeed = config.startSpeed;
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

   void Update()
{
    if (IsGameOver)
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        return;
    }

    ScrollSpeed = Mathf.Min(
        ScrollSpeed + config.speedIncreaseRate * Time.deltaTime,
        config.maxSpeed
    );

    Distance += ScrollSpeed * Time.deltaTime;
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

        Debug.Log("Game Over! Final Score: " + Mathf.FloorToInt(Distance));
    }
}
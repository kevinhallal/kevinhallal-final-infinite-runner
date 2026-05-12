using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text coinText;

    void Update()
    {
        if (GameManager.Instance == null || scoreText == null) return;

        int score = Mathf.FloorToInt(GameManager.Instance.Distance);
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + GameManager.Instance.HighScore;
        if (coinText != null)
    coinText.text = "Coins: " + GameManager.Instance.Coins;
    }
}
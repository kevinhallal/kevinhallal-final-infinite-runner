using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TMP_Text speedBoostAmountText;
[SerializeField] private TMP_Text magnetAmountText;
[SerializeField] private TMP_Text invincibilityAmountText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text coinText;

    void Update()
    {
        speedBoostAmountText.text = "x" + GameManager.Instance.SpeedBoostCount;
magnetAmountText.text = "x" + GameManager.Instance.MagnetCount;
invincibilityAmountText.text = "x" + GameManager.Instance.InvincibilityCount;
        if (GameManager.Instance == null || scoreText == null) return;

        int score = Mathf.FloorToInt(GameManager.Instance.Distance);
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + GameManager.Instance.HighScore;
        if (coinText != null)
   coinText.text = "Coins: " + GameManager.Instance.RunCoins 
              + " | Total: " + GameManager.Instance.TotalCoins;
              
    }
}
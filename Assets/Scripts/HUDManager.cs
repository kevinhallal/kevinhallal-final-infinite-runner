using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [Header("Powerup Animators")]
    [SerializeField] private Animator speedAnimator;
    [SerializeField] private Animator magnetAnimator;
    [SerializeField] private Animator invincibilityAnimator;

    [Header("Powerup Texts")]
    [SerializeField] private TMP_Text speedBoostAmountText;
    [SerializeField] private TMP_Text magnetAmountText;
    [SerializeField] private TMP_Text invincibilityAmountText;

    [Header("HUD Texts")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text coinText;

    [Header("Powerup Effects")]
    [SerializeField] private GameObject speedEffectOverlay;

    [Header("High Score Effect")]
    [SerializeField] private GameObject newHighScoreText;
    [SerializeField] private Animator newHighScoreAnimator;

    private bool hasPlayedHighScoreEffect;

    void Start()
    {
        if (newHighScoreText != null)
            newHighScoreText.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance == null) return;

        UpdateScoreUI();
        UpdateCoinUI();
        UpdatePowerupUI();

        CheckForNewHighScore();
    }

    private void UpdateScoreUI()
    {
        if (scoreText == null) return;

        int score = Mathf.FloorToInt(GameManager.Instance.Distance);

        scoreText.text = "Score: " + score;

        if (highScoreText != null)
        {
            highScoreText.text =
                "High Score: " +
                GameManager.Instance.HighScore;
        }
    }

    private void UpdateCoinUI()
    {
        if (coinText == null) return;

        coinText.text =
            "Coins: " +
            GameManager.Instance.RunCoins +
            " | Total: " +
            GameManager.Instance.TotalCoins;
    }

    private void UpdatePowerupUI()
    {
        // SPEED BOOST
        if (GameManager.Instance.IsGameOver)
        {
            if (speedEffectOverlay != null)
                speedEffectOverlay.SetActive(false);

            speedBoostAmountText.text =
                "x" +
                GameManager.Instance.SpeedBoostCount;
        }
        else if (GameManager.Instance.IsSpeedBoostActive)
        {
            speedBoostAmountText.text =
                GameManager.Instance
                    .SpeedBoostTimeLeft
                    .ToString("0.0") + "s";

            if (speedEffectOverlay != null)
                speedEffectOverlay.SetActive(true);
        }
        else
        {
            speedBoostAmountText.text =
                "x" +
                GameManager.Instance.SpeedBoostCount;

            if (speedEffectOverlay != null)
                speedEffectOverlay.SetActive(false);
        }

        // MAGNET
        if (GameManager.Instance.IsMagnetActive)
        {
            magnetAmountText.text =
                GameManager.Instance
                    .MagnetTimeLeft
                    .ToString("0.0") + "s";
        }
        else
        {
            magnetAmountText.text =
                "x" +
                GameManager.Instance.MagnetCount;
        }

        // INVINCIBILITY
        if (GameManager.Instance.IsInvincibilityActive)
        {
            invincibilityAmountText.text =
                GameManager.Instance
                    .InvincibilityTimeLeft
                    .ToString("0.0") + "s";
        }
        else
        {
            invincibilityAmountText.text =
                "x" +
                GameManager.Instance.InvincibilityCount;
        }
    }

    private void CheckForNewHighScore()
    {
        if (hasPlayedHighScoreEffect) return;

        int currentScore =
            Mathf.FloorToInt(
                GameManager.Instance.Distance
            );

        if (currentScore > GameManager.Instance.HighScore)
        {
            hasPlayedHighScoreEffect = true;

            if (newHighScoreText != null)
                newHighScoreText.SetActive(true);

            if (newHighScoreAnimator != null)
            {
                newHighScoreAnimator.Play(
                    "NewHighScorePop",
                    0,
                    0f
                );
            }
        }
    }

    public void PlaySpeedBoostEffect()
    {
        if (speedAnimator != null)
        {
            speedAnimator.Play(
                "PowerupBounce",
                0,
                0f
            );
        }
    }

    public void PlayMagnetEffect()
    {
        if (magnetAnimator != null)
        {
            magnetAnimator.Play(
                "PowerupBounce",
                0,
                0f
            );
        }
    }

    public void PlayInvincibilityEffect()
    {
        if (invincibilityAnimator != null)
        {
            invincibilityAnimator.Play(
                "PowerupBounce",
                0,
                0f
            );
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text runCoinsText;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            int score = Mathf.FloorToInt(
                GameManager.Instance.Distance
            );

            finalScoreText.text =
                "" + score;

            runCoinsText.text =
                "" + GameManager.Instance.RunCoins;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}
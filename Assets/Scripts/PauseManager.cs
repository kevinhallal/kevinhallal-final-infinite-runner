using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pauseButton;

    private bool isPaused;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
        {
            if (pauseUI != null)
                pauseUI.SetActive(false);

            if (pauseButton != null)
                pauseButton.SetActive(false);

            Time.timeScale = 1f;
            return;
        }

        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.IsGameOver)
            return;

        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0f : 1f;

        if (pauseUI != null)
            pauseUI.SetActive(isPaused);
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
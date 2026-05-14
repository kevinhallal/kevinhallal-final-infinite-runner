using UnityEngine;
using UnityEngine.InputSystem;

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

        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0f : 1f;

        if (pauseUI != null)
            pauseUI.SetActive(isPaused);
    }
}
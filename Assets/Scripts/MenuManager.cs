using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject settingsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    public void OpenSettings()
{
    settingsPanel.SetActive(true);
}

public void CloseSettings()
{
    settingsPanel.SetActive(false);
}
public void OpenShop()
{
    shopPanel.SetActive(true);
}

public void CloseShop()
{
    shopPanel.SetActive(false);
}
}
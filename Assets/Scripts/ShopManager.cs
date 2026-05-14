using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text totalCoinsText;
    [SerializeField] private GameObject shopPanel;

    [Header("Costs")]
    [SerializeField] private int speedBoostCost = 10;
    [SerializeField] private int magnetCost = 15;
    [SerializeField] private int invincibilityCost = 20;

    private void Update()
    {
        if (totalCoinsText != null)
        {
            totalCoinsText.text =
                "Coins: " +
                GameManager.Instance.TotalCoins;
        }
    }

    public void OpenShop()
    {
        if (shopPanel != null)
            shopPanel.SetActive(true);

        SFXManager.Instance?.PlayShopOpen();
    }

    public void CloseShop()
    {
        if (shopPanel != null)
            shopPanel.SetActive(false);
    }

    public void BuySpeedBoost()
    {
        if (GameManager.Instance.TotalCoins < speedBoostCost)
        {
            Debug.Log("Not enough coins.");
            return;
        }

        GameManager.Instance.TotalCoins -= speedBoostCost;

        PlayerPrefs.SetInt(
            "TotalCoins",
            GameManager.Instance.TotalCoins
        );

        GameManager.Instance.SpeedBoostCount++;

        PlayerPrefs.SetInt(
            "SpeedBoostCount",
            GameManager.Instance.SpeedBoostCount
        );

        PlayerPrefs.Save();

        SFXManager.Instance?.PlayPurchaseSuccess();

        Debug.Log("Bought Speed Boost");
    }

    public void BuyMagnet()
    {
        if (GameManager.Instance.TotalCoins < magnetCost)
        {
            Debug.Log("Not enough coins.");
            return;
        }

        GameManager.Instance.TotalCoins -= magnetCost;

        PlayerPrefs.SetInt(
            "TotalCoins",
            GameManager.Instance.TotalCoins
        );

        GameManager.Instance.MagnetCount++;

        PlayerPrefs.SetInt(
            "MagnetCount",
            GameManager.Instance.MagnetCount
        );

        PlayerPrefs.Save();

        SFXManager.Instance?.PlayPurchaseSuccess();

        Debug.Log("Bought Magnet");
    }

    public void BuyInvincibility()
    {
        if (GameManager.Instance.TotalCoins < invincibilityCost)
        {
            Debug.Log("Not enough coins.");
            return;
        }

        GameManager.Instance.TotalCoins -= invincibilityCost;

        PlayerPrefs.SetInt(
            "TotalCoins",
            GameManager.Instance.TotalCoins
        );

        GameManager.Instance.InvincibilityCount++;

        PlayerPrefs.SetInt(
            "InvincibilityCount",
            GameManager.Instance.InvincibilityCount
        );

        PlayerPrefs.Save();

        SFXManager.Instance?.PlayPurchaseSuccess();

        Debug.Log("Bought Invincibility");
    }
}
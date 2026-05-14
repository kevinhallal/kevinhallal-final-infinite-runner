using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TMP_Text totalCoinsText;

    private const int SpeedBoostCost = 10;
    private const int MagnetCost = 15;
    private const int InvincibilityCost = 20;

    private int totalCoins;

    void OnEnable()
    {
        LoadCoins();
        UpdateUI();
    }

    private void LoadCoins()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
    }

    private void UpdateUI()
    {
        totalCoinsText.text = "" + totalCoins;
    }

    public void BuySpeedBoost()
    {
        BuyPowerup(SpeedBoostCost, "SpeedBoostCount");
    }

    public void BuyMagnet()
    {
        BuyPowerup(MagnetCost, "MagnetCount");
    }

    public void BuyInvincibility()
    {
        BuyPowerup(InvincibilityCost, "InvincibilityCount");
    }

    private void BuyPowerup(int cost, string key)
    {
        if (totalCoins < cost)
        {
            Debug.Log("Not enough coins.");
            return;
        }

        totalCoins -= cost;

        int currentAmount = PlayerPrefs.GetInt(key, 0);
        PlayerPrefs.SetInt(key, currentAmount + 1);

        SaveCoins();
        UpdateUI();

        Debug.Log("Bought " + key);
    }
}
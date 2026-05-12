using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    void Update()
    {
        if (GameManager.Instance == null || scoreText == null) return;

        int score = Mathf.FloorToInt(GameManager.Instance.Distance);
        scoreText.text = "Score: " + score;
    }
}
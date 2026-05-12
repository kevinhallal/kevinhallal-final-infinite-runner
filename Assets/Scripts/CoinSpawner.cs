using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField, Range(0f, 1f)] private float spawnChance = 0.7f;

    private void OnEnable()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        if (coinPrefab == null || spawnPoints == null) return;

        foreach (Transform point in spawnPoints)
        {
            if (point == null) continue;

            if (Random.value <= spawnChance)
            {
                GameObject coin = Instantiate(coinPrefab, point.position, point.rotation, transform);
                coin.SetActive(true);
            }
        }
    }
}
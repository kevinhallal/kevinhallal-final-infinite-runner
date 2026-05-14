using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float safeLandingBuffer = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.Instance.IsInvincible)
        {
            Debug.Log("Hit ignored because player is invincible.");
            return;
        }

        Collider obstacleCollider = GetComponent<Collider>();
        Collider playerCollider = other;

        float obstacleTop = obstacleCollider.bounds.max.y;
        float playerBottom = playerCollider.bounds.min.y;

        if (playerBottom >= obstacleTop - safeLandingBuffer)
        {
            return;
        }

        GameManager.Instance.GameOver();
    }
}
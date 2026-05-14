using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    [Header("Gameplay Sounds")]
    [SerializeField] private AudioClip coinCollectSound;
    [SerializeField] private AudioClip gameStartSound;
    [SerializeField] private AudioClip deathSound;

    [Header("Powerup Sounds")]
    [SerializeField] private AudioClip invincibilitySound;
    [SerializeField] private AudioClip magnetSound;
    [SerializeField] private AudioClip speedBoostSound;

    [Header("Menu / Shop Sounds")]
    [SerializeField] private AudioClip shopOpenSound;
    [SerializeField] private AudioClip purchaseSuccessSound;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null) return;

        audioSource.PlayOneShot(clip);
    }

    public void PlayCoinCollect()
    {
        PlaySound(coinCollectSound);
    }

    public void PlayGameStart()
    {
        PlaySound(gameStartSound);
    }

    public void PlayDeath()
    {
        PlaySound(deathSound);
    }

    public void PlayInvincibility()
    {
        PlaySound(invincibilitySound);
    }

    public void PlayMagnet()
    {
        PlaySound(magnetSound);
    }

    public void PlaySpeedBoost()
    {
        PlaySound(speedBoostSound);
    }

    public void PlayShopOpen()
    {
        PlaySound(shopOpenSound);
    }

    public void PlayPurchaseSuccess()
    {
        PlaySound(purchaseSuccessSound);
    }
}
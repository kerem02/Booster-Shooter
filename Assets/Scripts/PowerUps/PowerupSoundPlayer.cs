using UnityEngine;

public class PowerupSoundPlayer : MonoBehaviour
{
    public static PowerupSoundPlayer instance;
    private AudioSource audioSource;

    [SerializeField] private AudioClip pickupSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }
}

using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupType powerupType;
    public float duration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpHandler powerhandler = other.GetComponent<PowerUpHandler>();

            if (PowerupSoundPlayer.instance != null)
            {
                PowerupSoundPlayer.instance.PlayPickupSound();
            }

            if (powerhandler != null)
            {
                powerhandler.ActivatePowerup(powerupType, duration);
            }
                Destroy(gameObject); // Destroy the powerup after collection
        }
    }
}

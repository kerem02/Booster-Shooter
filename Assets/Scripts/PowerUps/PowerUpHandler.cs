using UnityEngine;
using System.Collections;

public class PowerUpHandler : MonoBehaviour
{
    public bool isMultishot { get; private set; } = false;
    public bool isShield { get; private set; } = false;

    [SerializeField] private GameObject shieldVisualEffect;

    private Coroutine multishotCoroutine;
    private Coroutine shieldCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldVisualEffect.activeSelf)
        {
            shieldVisualEffect.transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
        }
    }

    public void ActivatePowerup(PowerupType type, float duration)
    {
        switch (type)
        {
            case PowerupType.Multishot:
                if (multishotCoroutine != null)
                {
                    StopCoroutine(multishotCoroutine);
                }
                 multishotCoroutine = StartCoroutine(MultishotPowerup(duration));
                break;

            case PowerupType.Shield:
                if (shieldCoroutine != null)
                {
                    StopCoroutine(shieldCoroutine);
                }
                shieldCoroutine = StartCoroutine(ShieldPowerup(duration));
                break;
        }
    }


    private IEnumerator MultishotPowerup(float duration)
    {
        isMultishot = true;
        yield return new WaitForSeconds(duration);
        isMultishot = false;
        multishotCoroutine = null;
    }

    private IEnumerator ShieldPowerup(float duration)
    {
        isShield = true;
        shieldVisualEffect.SetActive(true);
        yield return new WaitForSeconds(duration);
        isShield = false;
        shieldVisualEffect.SetActive(false);
        shieldCoroutine = null;
    }
}

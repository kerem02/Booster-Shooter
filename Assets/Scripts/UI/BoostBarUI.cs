using UnityEngine;
using UnityEngine.UI;

public class BoostBarUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Controller playerController;
    [SerializeField] private Image boostBarFill;

    private float boostDuration;
    private float boostCooldown;
    private float maxBarWidth;
    private float cooldownTimer = 0f;

    void Start()
    {
        if (playerController == null || boostBarFill == null)
        {
            Debug.LogError("BoostBarUI: Missing references!");
            enabled = false;
            return;
        }

        boostDuration = playerController.boostDuration;
        boostCooldown = playerController.boostCoolDown;

        // Geniþliði hatýrla
        maxBarWidth = boostBarFill.rectTransform.sizeDelta.x;

        // Baþlangýçta full dolu
        SetBarPercent(1f);
    }

    void Update()
    {
        if (playerController.isBoosting)
        {
            cooldownTimer = 0f;

            float percent = Mathf.Clamp01(boostBarFill.rectTransform.sizeDelta.x / maxBarWidth);
            percent -= Time.deltaTime / boostDuration;

            SetBarPercent(percent);
        }
        else
        {
            if (boostBarFill.rectTransform.sizeDelta.x < maxBarWidth)
            {
                cooldownTimer += Time.deltaTime;
                float percent = Mathf.Clamp01(cooldownTimer / boostCooldown);
                SetBarPercent(percent);
            }
        }
    }

    private void SetBarPercent(float percent)
    {
        if (boostBarFill != null)
        {
            float width = maxBarWidth * Mathf.Clamp01(percent);
            boostBarFill.rectTransform.sizeDelta = new Vector2(width, boostBarFill.rectTransform.sizeDelta.y);
        }
    }
}

using UnityEngine;

public class LaserGrow : MonoBehaviour
{
    [SerializeField] private float maxScaleY = 50f;
    [SerializeField] private float growDuration = 2f;

    private float elapsedTime = 0f;
    private Vector3 originalScale;
    private bool growing = false;

    void OnEnable()
    {
        originalScale = transform.localScale;
        transform.localScale = new Vector3(originalScale.x, 0f, originalScale.z);
        elapsedTime = 0f;
        growing = true;
    }

    void Update()
    {
        if (!growing) return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / growDuration);
        float newY = Mathf.Lerp(0f, maxScaleY, t);
        transform.localScale = new Vector3(originalScale.x, newY, originalScale.z);

        if (t >= 1f)
        {
            growing = false;
        }
    }

    void OnDisable()
    {
        transform.localScale = originalScale;
        growing = false;
    }
}

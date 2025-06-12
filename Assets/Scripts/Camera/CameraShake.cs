using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private CameraController cameraController;

    private void Awake()
    {
        instance = this;
        cameraController = GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogWarning("CameraShake: No CameraController found on the same GameObject.");
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-0.1f, 0.1f) * magnitude;
            float y = Random.Range(-0.1f, 0.1f) * magnitude;

            Vector3 shakeOffset = new Vector3(x, y, 0f);

            if (cameraController != null)
            {
                cameraController.SetShakeOffset(shakeOffset);
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Sarsýntý bittiðinde offset'i sýfýrla
        if (cameraController != null)
        {
            cameraController.SetShakeOffset(Vector3.zero);
        }
    }
}

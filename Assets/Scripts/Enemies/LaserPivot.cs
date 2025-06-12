using UnityEngine;

public class LaserPivot : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public Transform bossTransform;

    private Quaternion ownRotation;

    void Start()
    {
        ownRotation = transform.rotation;
    }

    void Update()
    {
        // Her karede kendi ekseni etraf�nda d�n
        ownRotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {
        // Pozisyonu boss�un pozisyonuna sabitleriz
        if (bossTransform != null)
        {
            transform.position = bossTransform.position;
        }

        // Ancak rotasyonu sadece kendi hesaplad���m�z gibi kullan�r�z
        transform.rotation = ownRotation;
    }
}

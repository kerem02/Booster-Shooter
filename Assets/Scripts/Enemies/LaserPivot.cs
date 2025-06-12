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
        // Her karede kendi ekseni etrafýnda dön
        ownRotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {
        // Pozisyonu boss’un pozisyonuna sabitleriz
        if (bossTransform != null)
        {
            transform.position = bossTransform.position;
        }

        // Ancak rotasyonu sadece kendi hesapladýðýmýz gibi kullanýrýz
        transform.rotation = ownRotation;
    }
}

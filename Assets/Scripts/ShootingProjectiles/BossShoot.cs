using UnityEngine;

public class BossShoot : MonoBehaviour
{

    public GameObject projectilePrefab = null;
    public float fireRate = 0.05f;
    public float projectileSpread = 1.0f;
    private float lastFired = Mathf.NegativeInfinity;
    public GameObject fireEffect;
    public Transform projectileHolder = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if(Time.timeSinceLevelLoad -lastFired > fireRate)
        {
            SpawnProjectile();

            if(fireEffect != null)
            {
                Instantiate(fireEffect, transform.position, transform.rotation, null);
            }

            lastFired = Time.timeSinceLevelLoad;
        }
    }

    public void SpawnProjectile()
    {
        // Check that the prefab is valid
        if (projectilePrefab != null)
        {
            // Create the projectile
            GameObject projectileGameObject = Instantiate(projectilePrefab, transform.position, transform.rotation, null);

            // Account for spread
            Vector3 rotationEulerAngles = projectileGameObject.transform.rotation.eulerAngles;
            rotationEulerAngles.z += Random.Range(-projectileSpread, projectileSpread);
            projectileGameObject.transform.rotation = Quaternion.Euler(rotationEulerAngles);

            // Keep the heirarchy organized
            if (projectileHolder != null)
            {
                projectileGameObject.transform.SetParent(projectileHolder);
            }
        }
    }
}

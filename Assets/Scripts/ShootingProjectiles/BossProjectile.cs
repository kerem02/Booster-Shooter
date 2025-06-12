using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float projectileSpeed = 8.0f;
    public float rotateSpeed = 100f;
    private Transform player;
    public float trackingDuration = 2f;
    private float trackingTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj != null)
        {
            player = playerObj.transform;
        }
        trackingTimer = trackingDuration;
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    public void MoveProjectile()
    {
        if (player != null && trackingTimer > 0f)
        {
            trackingTimer -= Time.deltaTime;
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        transform.position = transform.position + transform.right * projectileSpeed * Time.deltaTime;
    }
}

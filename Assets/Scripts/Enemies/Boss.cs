using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform player;
    private float rotationSpeed = 5f;
    public BossShoot gun = null;
    [SerializeField] private GameObject laserPivot;
    [SerializeField] private float laserAttackDuration = 4f;
    [SerializeField] private float laserAttackCooldown = 6f;
    private bool isLaserActive = false;
    private float nextLaserAttackTime = 6f;
    [SerializeField] private AudioSource alarmSound;
    [SerializeField] private AudioSource laserSound;
    private bool alarmPlayed = false;
    private float activateRange = 20f;
    private bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (player != null)
            {
                LookAtPlayer();
            }

            TrytoShoot();

            CheckAlarm();

            if (Time.time >= nextLaserAttackTime && !isLaserActive)
            {
                ActivateLaserAttack();
            }
        }

        else
        {
            ActivateBoss();
        }

    }

    void LookAtPlayer()
    {
        Vector2 direction = (player.position -transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void TrytoShoot()
    {
        if (gun != null)
        {
            gun.Fire();
        }
    }

    private void CheckAlarm()
    {
        if(!alarmPlayed && Time.time >= nextLaserAttackTime - 2f)
        {
            if(alarmSound != null)
            {
                alarmSound.Play();
            }
            
            alarmPlayed = true;
        }
    }

    private void ActivateLaserAttack()
    {
        
        if (alarmSound != null)
        {
            alarmSound.Stop();
        }

        if (laserPivot != null)
        {
            if(laserSound != null)
            {
                laserSound.Play();
            }
            laserPivot.SetActive(true);
            isLaserActive = true;

            Invoke(nameof(DeactivateLaserAttack), laserAttackDuration);
        }
    }

    private void DeactivateLaserAttack()
    {
        foreach (Transform child in laserPivot.transform)
        {
            var shrink = child.GetComponent<LaserShrink>();
            if (shrink != null)
            {
                shrink.StartShrink();
            }
        }

        isLaserActive = false;
        nextLaserAttackTime = Time.time + laserAttackCooldown;
        alarmPlayed = false;
    }

    private void ActivateBoss()
    {
        if (Vector2.Distance(player.position, transform.position) < activateRange)
        {
            isActive = true;
            nextLaserAttackTime = Time.time + laserAttackCooldown;
        }
    }
}

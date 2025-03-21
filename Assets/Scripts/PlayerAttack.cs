using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject bulletPrefab;  
    public Transform attackPoint;   
    public float bulletSpeed = 10f; 

    [Header("Cooldown Settings")]
    public float attackCooldown = 0.5f; 
    private float lastAttackTime = 0f;   

    [Header("Bullet Settings")]
    public float bulletLifetime = 5f;  

    private PlayerMovement playerMovement;  

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.J) && Time.time >= lastAttackTime + attackCooldown)
        {
            Shoot();
            lastAttackTime = Time.time;  
        }
    }

    void Shoot()
    {
        float direction = playerMovement.isFacingRight ? 1f : -1f;

        Vector3 spawnPosition = attackPoint.position + new Vector3(direction * 0.5f, 0f, 0f);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(direction * bulletSpeed, 0f);

        Vector3 bulletScale = bullet.transform.localScale;
        bulletScale.x = Mathf.Abs(bulletScale.x) * direction;
        bullet.transform.localScale = bulletScale;

        Destroy(bullet, bulletLifetime);
    }
}

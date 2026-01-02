using UnityEngine;

public class PurpleEnemy : Enemy {
    [SerializeField] private float speed;

    [SerializeField] private float shootingInterval;
    private float intervalReset;

    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;

    [SerializeField] private GameObject laserBullet;


    void Start() {
        intervalReset = shootingInterval;
        rigidBody.linearVelocity = Vector2.down * speed;
    }


    void Update() {
        // Gap Between Each Laser Shoot
        shootingInterval -= Time.deltaTime;
        if (shootingInterval <= 0) {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    private void Shoot() {
        Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
        Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public override void HurtSequence() {
        base.HurtSequence();
    }

    public override void DeathSequence() {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

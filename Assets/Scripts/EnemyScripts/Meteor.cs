using UnityEngine;

public class Meteor : Enemy {

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;

    [SerializeField] private float zRotateSpeed;

    void Start() {
        speed = Random.Range(minSpeed, maxSpeed);
        rigidBody.linearVelocity = Vector2.down * speed;
    }

    void Update() {
        transform.Rotate(0, 0, zRotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence() {
        // Nothing - Placeholder
    }

    public override void DeathSequence() {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if (otherCollider.CompareTag("Player")) {
            // Cause damage to player on Collide
            PlayerStats player = otherCollider.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            // Destroy Meteor
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

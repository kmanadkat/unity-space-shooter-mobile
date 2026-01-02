using UnityEngine;

public class GreenFly : Enemy {

    [SerializeField] private float speed;

    void Start() {
        rigidBody.linearVelocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if (otherCollider.CompareTag("Player")) {
            // Cause damage to player on Collide change
            PlayerStats player = otherCollider.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            // Destroy Meteor
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public override void HurtSequence() {
        base.HurtSequence();
    }

    public override void DeathSequence() {
        base.DeathSequence();
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

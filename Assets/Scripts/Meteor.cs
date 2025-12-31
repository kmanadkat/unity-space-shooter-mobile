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
        // TODO
        // base.HurtSequence();
    }

    public override void DeathSequence() {
        // TODO
        // base.DeathSequence();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if (otherCollider.CompareTag("Player")) {
            Destroy(otherCollider.gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

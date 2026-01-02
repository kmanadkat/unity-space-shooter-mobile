using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rigidBody;

    // Damage can be caused by Enemy to Player
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;
    void Start() {

    }

    void Update() { }

    public void TakeDamage(float damage) {
        health -= damage;
        HurtSequence();

        // Destroy Enemy
        if (health <= 0) {
            DeathSequence();
        }
    }

    public virtual void HurtSequence() {
        // TODO: Damage Animation
    }

    public virtual void DeathSequence() {
        // TODO: Destroy Animation
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rigidBody;

    // Damage can be caused by Enemy to Player
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;

    [SerializeField] private Animator anim;

    public void TakeDamage(float damage) {
        health -= damage;
        HurtSequence();

        // Destroy Enemy
        if (health <= 0) {
            DeathSequence();
        }
    }

    public virtual void HurtSequence() {
        if (anim != null) {
            // Check if Damage Animation is already running
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) {
                return;
            }
            anim.SetTrigger("Damage");
        }
    }

    public virtual void DeathSequence() {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

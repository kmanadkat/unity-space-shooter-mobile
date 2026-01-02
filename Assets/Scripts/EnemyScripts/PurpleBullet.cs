using UnityEngine;

public class PurpleBullet : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rb;

    void Start() {
        rb.linearVelocity = -transform.up * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collided");
        PlayerStats player = collision.GetComponent<PlayerStats>();
        player.PlayerTakeDamage(damage);
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class PurpleBullet : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rb;

    void Start() {
        Debug.Log("PurpleBullet Start");
        rb.linearVelocity = -transform.up * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision) {
        PlayerStats player = collision.GetComponent<PlayerStats>();
        player.PlayerTakeDamage(damage);
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Debug.Log("PurpleBullet OnBecameInvisible");
        Destroy(gameObject);
    }
}

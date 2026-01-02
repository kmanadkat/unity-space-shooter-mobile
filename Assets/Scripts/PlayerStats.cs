using UnityEngine;

public class PlayerStats : MonoBehaviour {
    [SerializeField] private float maxHealth;
    private float currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void PlayerTakeDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}

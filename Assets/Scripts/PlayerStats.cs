using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PlayerStats : MonoBehaviour {
    [SerializeField] private float maxHealth;
    private float currentHealth;

    // UI Health Bar Fill
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;

    void Start() {
        currentHealth = maxHealth;
        healthFill.fillAmount = currentHealth / maxHealth;
    }

    public void PlayerTakeDamage(float damage) {
        currentHealth -= damage;
        healthFill.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0) {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

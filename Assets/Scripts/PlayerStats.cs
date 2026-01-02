using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PlayerStats : MonoBehaviour {
    [SerializeField] private float maxHealth;
    private float currentHealth;

    // UI Health Bar Fill
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private Animator anim;
    private bool canPlayAnim = true;

    void Start() {
        currentHealth = maxHealth;
        healthFill.fillAmount = currentHealth / maxHealth;
    }

    public void PlayerTakeDamage(float damage) {
        currentHealth -= damage;
        healthFill.fillAmount = currentHealth / maxHealth;

        // Play Animation
        if (canPlayAnim) {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }
        if (currentHealth <= 0) {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator AntiSpamAnimation() {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }
}

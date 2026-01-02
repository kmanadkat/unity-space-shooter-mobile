using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemies;
    private float enemyTimer = 0;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;
    private int enemyIndex;

    private Camera mainCamera;
    private float maxLeft;
    private float maxRight;
    private float spawnPositionY;

    void Start() {
        mainCamera = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update() {
        enemyTimer += Time.deltaTime;

        // Spawn Enemy
        if (enemyTimer > enemySpawnTime) {
            enemyIndex = Random.Range(0, enemies.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(maxLeft, maxRight), spawnPositionY, -5);
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(enemies[enemyIndex], spawnPosition, spawnRotation);
            enemyTimer = 0;
        }
    }

    private IEnumerator SetBoundaries() {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(1f, 0f)).x;

        spawnPositionY = mainCamera.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}

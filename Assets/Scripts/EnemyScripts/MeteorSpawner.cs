using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float spawnTime;
    private float timer = 0;
    private int meteorIndex;

    private Camera mainCamera;
    private float maxLeft;
    private float maxRight;
    private float spawnPositionY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        mainCamera = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        // Spawn Meteor
        if (timer > spawnTime) {
            meteorIndex = Random.Range(0, meteors.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(maxLeft, maxRight), spawnPositionY, -5);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

            GameObject newMeteor = Instantiate(meteors[meteorIndex], spawnPosition, spawnRotation);
            float newMeteorSize = Random.Range(0.9f, 1.1f);
            newMeteor.transform.localScale = new Vector3(newMeteorSize, newMeteorSize, 1);
            timer = 0;
        }
    }


    private IEnumerator SetBoundaries() {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(1f, 0f)).x;

        spawnPositionY = mainCamera.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}

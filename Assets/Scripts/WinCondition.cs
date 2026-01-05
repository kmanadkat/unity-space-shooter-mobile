using UnityEngine;

public class WinCondition : MonoBehaviour {
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawners;


    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (EndGameManager.endManager.gameOver) {
            return;
        }

        timer += Time.deltaTime;

        // Deactivate Spawners after win time
        if (timer >= possibleWinTime) {
            for (int i = 0; i < spawners.Length; i++) {
                spawners[i].SetActive(false);
            }

            // Check if the player survived after last spawned meteor / enemy
            // win or lose section
            // GAME MANAGER
            EndGameManager.endManager.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}

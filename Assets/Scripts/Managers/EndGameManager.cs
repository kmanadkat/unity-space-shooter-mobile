using System.Collections;
using UnityEngine;

public class EndGameManager : MonoBehaviour {
    public static EndGameManager endManager;
    public bool gameOver = false;

    private PanelController panelController;

    void Awake() {
        endManager = this;
    }

    void Start() {

    }

    public void RegisterPanelController(PanelController pc) {
        panelController = pc;
    }

    public void WinGame() {
        // Activate the panel
        panelController.ActivateWin();
        // Unlock the next level
        // score
    }

    public void LoseGame() {
        panelController.ActivateLose();
    }

    public void ResolveGame() {
        if (gameOver == false) {
            WinGame();
        }
        else {
            LoseGame();
        }
    }

    private IEnumerator ResolveSequence() {
        yield return new WaitForSeconds(2f);
        ResolveGame();
    }

    public void StartResolveSequence() {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public void LoadLevelString(string levelName) {
        FadeCanvas.fader.NewLevelLoaderString(levelName);
    }

    public void LoadLevelIndex(int sceneIndex) {
        FadeCanvas.fader.NewLevelLoaderInt(sceneIndex);
    }

    public void LevelRestart() {
        FadeCanvas.fader.NewLevelLoaderInt(SceneManager.GetActiveScene().buildIndex);
    }
}

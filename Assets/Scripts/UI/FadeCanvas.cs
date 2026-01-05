using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvas : MonoBehaviour {
    public static FadeCanvas fader;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

    private void Awake() {
        if (fader == null) {
            fader = this;
            DontDestroyOnLoad(fader);
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() {
        fadeStarted = false;
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator FadeOutString(string levelName) {
        if (fadeStarted) {
            yield break;
        }

        fadeStarted = true;
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        // Load Level
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(0.1f);
        // Fade In - Show New Level
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOutInt(int levelIndex) {
        if (fadeStarted) {
            yield break;
        }

        fadeStarted = true;
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        // Load Level
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(0.1f);
        // Fade In - Show New Level
        StartCoroutine(FadeIn());
    }

    public void NewLevelLoaderString(string levelName) {
        StartCoroutine(FadeOutString(levelName));
    }

    public void NewLevelLoaderInt(int levelIndex) {
        StartCoroutine(FadeOutInt(levelIndex));
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class FadeCanvas : MonoBehaviour {
    public static FadeCanvas fader;

    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
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
        loadingScreen.SetActive(false);
        fadeStarted = false;
        while (canvasGroup.alpha > 0) {
            if (fadeStarted) {
                yield break;
            }
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator FadeOutString(string levelName) {
        if (fadeStarted || canvasGroup.alpha != 0) {
            yield break;
        }

        fadeStarted = true;
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        // Load Level
        // SceneManager.LoadScene(levelName);
        // With Progress Bar START
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while (!ao.isDone) {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if (ao.progress == 0.9f) {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
        // With Progress Bar END
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
        // SceneManager.LoadScene(levelIndex);
        // With Progress Bar START
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelIndex);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while (!ao.isDone) {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if (ao.progress == 0.9f) {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
        // With Progress Bar END
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

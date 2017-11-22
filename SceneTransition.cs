// made by Koen 🌲

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public static SceneTransition instance;

    private static float transitionSpeed = 2;

    private static float overlayAlpha = 0;
    private GUIStyle currentStyle = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void OnGUI() {
        if (currentStyle == null) {
            currentStyle = new GUIStyle(GUI.skin.box);
        }

        currentStyle.normal.background = MakeTexture.MakeTex(2, 2, new Color(0f, 0f, 0f, overlayAlpha));

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", currentStyle);
    }

    public void StartTransition(int sceneIndex) {
        StartCoroutine(TransitionToScene(sceneIndex));
    }

    private IEnumerator TransitionToScene(int sceneIndex) {
        while (overlayAlpha < 1) {
            overlayAlpha += Time.deltaTime * transitionSpeed;

            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoad.isDone) {
            yield return null;
        }

        while (overlayAlpha > 0) {
            overlayAlpha -= Time.deltaTime * transitionSpeed;

            yield return null;
        }
    }

    public void StartTransition(string sceneName) {
        StartCoroutine(TransitionToScene(sceneName));
    }

    private IEnumerator TransitionToScene(string sceneName) {
        while (overlayAlpha < 1) {
            overlayAlpha += Time.deltaTime * transitionSpeed;

            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone) {
            yield return null;
        }

        while (overlayAlpha > 0) {
            overlayAlpha -= Time.deltaTime * transitionSpeed;

            yield return null;
        }
    }
}

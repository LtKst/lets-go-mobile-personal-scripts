// made by Koen 🌲

using UnityEngine;

public class TapLoadScene : MonoBehaviour {

    [SerializeField]
    private int sceneIndex;

    private void Update() {

        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
            SceneTransition.instance.StartTransition(sceneIndex);
        }
    }
}

// made by Koen 🌲

using UnityEngine;
using UnityEngine.UI;

public class EnlargeImage : MonoBehaviour {

    private Image image;

    [SerializeField]
    private Vector2 newSize;
    [SerializeField]
    private float speed;

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Update() {
        image.rectTransform.sizeDelta = Vector2.Lerp(image.rectTransform.sizeDelta, newSize, Time.deltaTime * speed);
    }
}

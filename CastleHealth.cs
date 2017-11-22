// made by Koen 🌲

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleHealth : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    [SerializeField]
    private bool isEnemy;
    [SerializeField]
    private int winSceneIndex = 0;
    [SerializeField]
    private int loseSceneIndex = 0;


    private bool isDead;

    [Header("UI")]
    [SerializeField]
    private Image healthBarImage;
    [SerializeField]
    private float healthBarWidth = 150;
    [SerializeField]
    private Text healthAmountText;
    [SerializeField]
    private bool isRightSide;

    private void Awake() {
        currentHealth = maxHealth;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(Random.Range(5, 25));
        }

        UpdateUI();
    }

    public void TakeDamage(int damageAmount) {
        if (currentHealth > 0) {
            if (currentHealth - damageAmount < 0) {
                currentHealth = 0;
            }
            else {
                currentHealth -= damageAmount;
            }
        }

        if (currentHealth <= 0 && !isDead) {
            Die();
        }
    }

    private void Die() {
        isDead = true;

        SceneManager.LoadScene(isEnemy ? winSceneIndex : loseSceneIndex);
    }

    private void UpdateUI() {
        if (!isRightSide) {
            healthBarImage.rectTransform.offsetMax = Vector2.Lerp
                (healthBarImage.rectTransform.offsetMax,
                new Vector2(0f - (healthBarWidth / maxHealth) * (maxHealth - currentHealth), healthBarImage.rectTransform.offsetMax.y),
                Time.deltaTime * 5);
        }
        else {
            healthBarImage.rectTransform.offsetMin = Vector2.Lerp
                (healthBarImage.rectTransform.offsetMin,
                new Vector2(0f + (healthBarWidth / maxHealth) * (maxHealth - currentHealth), healthBarImage.rectTransform.offsetMin.y),
                Time.deltaTime * 5);
        }

        healthAmountText.text = currentHealth + "/" + maxHealth;
    }
}

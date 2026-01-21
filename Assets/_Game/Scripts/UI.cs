using TMPro;
using UnityEngine;

public class UI : MonoBehaviour {
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _healthText;

    [Header("Settings")]
    private readonly int _health = 100;
    private int _currentHealth;

    void Start() {
        _healthText.text = _health.ToString();
        _currentHealth = _health;
    }

    void Update() {
        UpdateHealthUI();
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
    }

    public void UpdateHealthUI() {
        _healthText.text = _currentHealth.ToString();
    }
}

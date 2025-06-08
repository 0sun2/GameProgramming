using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerController player;

    void OnEnable()
    {
        PlayerController.OnHealthChanged += UpdateHealth;
    }

    void OnDisable()
    {
        PlayerController.OnHealthChanged -= UpdateHealth;
    }

    void Start()
    {
        if (player != null)
            UpdateHealth(player.GetCurrentHealth());
    }

    void UpdateHealth(int newHealth)
    {
        healthText.text = $"HP: {newHealth}";
    }
}
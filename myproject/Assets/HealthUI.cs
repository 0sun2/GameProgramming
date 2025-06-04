using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerController player;

    void Update()
    {
        if (player != null)
            healthText.text = $"HP: {player.GetCurrentHealth()}";
    }
}
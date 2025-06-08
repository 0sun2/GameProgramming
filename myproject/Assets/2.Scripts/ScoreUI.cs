using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void OnEnable()
    {
        EnemySpawner.OnScoreChanged += UpdateScore;
    }

    void OnDisable()
    {
        EnemySpawner.OnScoreChanged -= UpdateScore;
    }

    void Start()
    {
        UpdateScore(EnemySpawner.GetScore());
    }

    void UpdateScore(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Inspector에서 3개 프리팹 할당
    public float spawnInterval = 2f;
    public float minY = -3f;
    public float maxY = 3f;
    public float spawnXRight = 10f; // 오른쪽 끝
    public float spawnXLeft = -10f; // 왼쪽 끝
    public float intervalDecreaseTime = 5f; // 몇 초마다 스폰 속도 증가
    public float minInterval = 0.5f; // 최소 스폰 간격

    private float timer = 0f;
    private float intervalTimer = 0f;
    private static int score = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void Update()
    {
        timer += Time.deltaTime;
        intervalTimer += Time.deltaTime;
        if (intervalTimer >= intervalDecreaseTime && spawnInterval > minInterval)
        {
            spawnInterval = Mathf.Max(minInterval, spawnInterval - 0.2f);
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
            intervalTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int idx = Random.Range(0, enemyPrefabs.Length);
        float y = Random.Range(minY, maxY);

        // 0이면 왼쪽, 1이면 오른쪽
        bool spawnRight = Random.value > 0.5f;
        float x = spawnRight ? spawnXRight : spawnXLeft;

        // 방향 설정 (오른쪽에서 나오면 왼쪽으로, 왼쪽에서 나오면 오른쪽으로)
        GameObject enemy = Instantiate(enemyPrefabs[idx], new Vector3(x, y, 0), Quaternion.identity);
        EnemyController ctrl = enemy.GetComponent<EnemyController>();
        ctrl.moveDirection = spawnRight ? Vector2.left : Vector2.right;

        // 방향에 따라 Sprite 반전
        Vector3 scale = enemy.transform.localScale;
        if (!spawnRight)
            scale.x = -Mathf.Abs(scale.x); // 왼쪽에서 스폰: 오른쪽 이동, 반전
        else
            scale.x = Mathf.Abs(scale.x);  // 오른쪽에서 스폰: 왼쪽 이동, 원래대로
        enemy.transform.localScale = scale;
    }

    public static void AddScore(int value = 1)
    {
        score += value;
        Debug.Log($"Score: {score}");
    }

    public static int GetScore()
    {
        return score;
    }
}
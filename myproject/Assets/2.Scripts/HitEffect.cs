using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float destroyTime = 0.05f; // 효과가 사라질 시간 (초)

    void Start()
    {
        Destroy(gameObject, destroyTime); // destroyTime 초 후에 효과 오브젝트를 파괴
    }
} 
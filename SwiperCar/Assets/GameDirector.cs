using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI�� ����ϴ� �� �ʿ��ϴ�
using TMPro;  // TextMeshPro�� ����ϴ� �� �ʿ��ϴ�
public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;

    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("distance");
    }

    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        this.distance.GetComponent<TextMeshProUGUI>().text = "�Ÿ�: " + length.ToString("F2") + "m";
    }
}

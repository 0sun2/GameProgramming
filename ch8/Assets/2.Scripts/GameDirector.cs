using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;
    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    void Start()
    {
        this.generator = GameObject.Find("ItemGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    void Update()
    {
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameters(10000.0f, 0, 0f);
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameters(0.7f, 3, 0.3f);
        }
        else if (5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameters(0.8f, 2, 0.6f);
        }
        else if (10 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameters(0.8f, 2, 0.4f);
        }
        else if (20 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameters(1.0f, 2, 0.2f);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }
}

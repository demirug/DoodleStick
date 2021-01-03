using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject prefab;
    public Text scoreText;

    private static float startTime;
    private int spawned = 0;
    private long lastSpawn = 0;
    private bool active = false;

    private List<GameObject> objects = new List<GameObject>();
    private System.Random random = new System.Random();


    private void Start()
    {
        this.scoreText.text = "0";
        this.lastSpawn = DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1500;
    }

    void FixedUpdate()
    {
        if (!this.active) return;
        if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastSpawn >= 900)
        {
            for (int i = 0; i < 3; i++)
            {
                if (spawned != 2 && random.Next(1, 5) <= 2)
                {
                    this.objects.Add(Instantiate(this.prefab, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + i + 0.1f), Quaternion.identity));
                    this.spawned++;
                }
            }
            this.spawned = 0;
            
            Logic.userData.currentScore += 20;
            this.scoreText.text = Logic.userData.currentScore.ToString();

            lastSpawn = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }

    public void start()
    {
        startTime = Time.realtimeSinceStartup;
        this.active = true;
    }

    public static float aliveTime()
    {
        return Time.realtimeSinceStartup - startTime;
    }

    public void stop()
    {
        this.scoreText.text = "0";
        this.active = false;
        foreach (GameObject obj in this.objects)
        {
            Destroy(obj);
        }
        this.objects.Clear();
    }
}

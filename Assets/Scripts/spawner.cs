using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameSettings;
    private Transform[] spawnPoints;
    bool spawned = false;
    void Start()
    {

        spawnPoints = GetComponentsInChildren<Transform>();
        //print(spawnPoints.Length);
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameSettings.GetComponent<GameSettings>().gaming)
        {
            
            if (!spawned)
            {
                Invoke("Spawn", 0.5f);
                spawned = true;
            }
        }
        
    }

    void Spawn()
    {
        spawned = false;
        System.Random rand = new System.Random();
        //print(rand.Next(spawnPoints.Length));
        GameObject intedEnemy = Instantiate(enemy);
        intedEnemy.transform.position = spawnPoints[rand.Next(spawnPoints.Length)].position;
        //intedEnemy.transform.position = spawnPoints[5].position;
    }
}

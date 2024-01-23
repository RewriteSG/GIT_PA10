﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the spawning of obstacles
public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;
    [SerializeField] private GameObject Obstacle = null;
    [SerializeField] private float SpawnInterval = 1;
    private float NextSpawn = 0;
    public List<GameObject> obstacles = new List<GameObject>();
    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        if(Time.time >= NextSpawn)
        {
            NextSpawn = Time.time + SpawnInterval;
            Vector3 SpawnPos = new Vector3(8, Random.Range(-3, 3), 0);

            obstacles.Add(Instantiate(Obstacle, SpawnPos, Quaternion.identity));
        }
    }
}

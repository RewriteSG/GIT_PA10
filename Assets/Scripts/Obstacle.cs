﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the behavior of individual obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    bool isPassed = false;
    void Update()
    {
        if (transform.position.x <= -8)
        {
            ObstacleSpawner.instance.obstacles.Remove(gameObject);
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
        }
        if (transform.position.x <= GameManager.instance.Player.transform.position.x && !isPassed && transform.position.x > -8)
        {
            isPassed = true;
            GameManager.instance.UpdateScore(1);
        }
    }
}

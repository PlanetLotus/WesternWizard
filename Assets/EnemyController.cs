﻿using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        if (Player == null)
        {
            throw new InvalidOperationException("Player must be set in editor.");
        }

        rb = GetComponent<Rigidbody2D>();

        bullet = (GameObject)Resources.Load("Bullet");

        // Shoot at player every second
        InvokeRepeating("Shoot", 0, 1);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-1, rb.velocity.y);
    }

    private void Shoot()
    {
        int yOffset = Random.Range(-1, 2);
        Instantiate(bullet, new Vector3(transform.position.x - 1, 1.5f + yOffset), bullet.transform.rotation);
    }

    private Rigidbody2D rb;
    private GameObject bullet;
}

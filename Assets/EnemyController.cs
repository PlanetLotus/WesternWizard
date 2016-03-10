using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        if (Player == null)
        {
            throw new InvalidOperationException("Player must be set in editor.");
        }

        bullet = (GameObject)Resources.Load("Bullet");

        // Shoot at player every second
        InvokeRepeating("Shoot", 0, 1);
    }

    private void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x - 1, 1.5f), bullet.transform.rotation);
    }

    private GameObject bullet;
}

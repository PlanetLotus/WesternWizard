using System;
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
        // Dumbfire toward player's head, torso, or legs
        int yOffset = Random.Range(0, 3);
        Vector3 startingPosition = new Vector3(transform.position.x - 1, 1.5f);

        Vector3 direction = (Player.transform.GetChild(yOffset).position - startingPosition).normalized;

        GameObject newBullet = (GameObject)Instantiate(bullet, startingPosition, bullet.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction * 10;
    }

    private Rigidbody2D rb;
    private GameObject bullet;
}

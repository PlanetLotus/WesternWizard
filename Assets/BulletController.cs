using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-10, 0);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Game over - player was hit.");
        Destroy(gameObject);
    }

    private Rigidbody2D rb;
}

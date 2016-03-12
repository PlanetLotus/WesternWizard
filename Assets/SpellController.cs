using UnityEngine;

public class SpellController : MonoBehaviour
{
    public float xSpeed = 6;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Layer 11 is Enemy. We want spells to collide with walls but not destroy them.
        if (coll.gameObject.layer == 11)
        {
            Destroy(coll.gameObject);
        }

        Destroy(gameObject);
    }

    private Rigidbody2D rb;
}

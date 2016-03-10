using UnityEngine;

public class SpellController : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(6, 0);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }

    private Rigidbody2D rb;
}

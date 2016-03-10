using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool FacingRight = true;

    public float MoveForce = 365f;
    public float MaxSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spell = (GameObject)Resources.Load("Spell");
        nextShotTimeStamp = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && nextShotTimeStamp <= Time.time)
        {
            Shoot();
            nextShotTimeStamp = Time.time + shotCooldownInSeconds;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb.velocity.x < MaxSpeed)
        {
            rb.AddForce(Vector2.right * h * MoveForce);
        }

        if (Mathf.Abs(rb.velocity.x) > MaxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * MaxSpeed, rb.velocity.y);
        }

        if ((h > 0 && !FacingRight) || (h < 0 && FacingRight))
        {
            Flip();
        }
    }

    private void Shoot()
    {
        Instantiate(spell, new Vector3(transform.position.x + 1, 1.5f), spell.transform.rotation);
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private Rigidbody2D rb;
    private GameObject spell;
    private float nextShotTimeStamp;

    private const float shotCooldownInSeconds = 1;
}

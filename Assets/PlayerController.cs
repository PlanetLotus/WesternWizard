using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool FacingRight = true;

    public float MoveForce = 365f;
    public float MaxSpeed = 5f;

    public float SpellCooldownInSeconds = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        spell = (GameObject)Resources.Load("Spell");

        // Bad...depends on ordering of child objects in prefab
        headSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        torsoSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        legsSprite = transform.GetChild(2).GetComponent<SpriteRenderer>();

        nextShotTimeStamp = 0;
    }

    private void Update()
    {
        // Can't shoot while dodging
        if (!isDodging && Input.GetKeyDown(KeyCode.Q))
        {
            DodgeTop();
        }
        else if (!isDodging && Input.GetKeyDown(KeyCode.W))
        {
            DodgeMiddle();
        }
        else if (!isDodging && Input.GetKeyDown(KeyCode.E))
        {
            DodgeBottom();
        }
        else if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.E))
        {
            ResetDodge();
        }
        else if (!isDodging && Input.GetKeyDown(KeyCode.Space) && nextShotTimeStamp <= Time.time)
        {
            Shoot();
            nextShotTimeStamp = Time.time + SpellCooldownInSeconds;
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

    private void DodgeTop()
    {
        torsoSprite.enabled = false;
        legsSprite.enabled = false;

        // Layer 12 is "PlayerDodging"
        torsoSprite.gameObject.layer = 12;
        legsSprite.gameObject.layer = 12;

        isDodging = true;
    }

    private void DodgeMiddle()
    {
        headSprite.enabled = false;
        legsSprite.enabled = false;

        // Layer 12 is "PlayerDodging"
        headSprite.gameObject.layer = 12;
        legsSprite.gameObject.layer = 12;

        isDodging = true;
    }

    private void DodgeBottom()
    {
        headSprite.enabled = false;
        torsoSprite.enabled = false;

        // Layer 12 is "PlayerDodging"
        headSprite.gameObject.layer = 12;
        torsoSprite.gameObject.layer = 12;

        isDodging = true;
    }

    private void ResetDodge()
    {
        headSprite.enabled = true;
        torsoSprite.enabled = true;
        legsSprite.enabled = true;

        // Layer 8 is "Player"
        headSprite.gameObject.layer = 8;
        torsoSprite.gameObject.layer = 8;
        legsSprite.gameObject.layer = 8;

        isDodging = false;
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
    private BoxCollider2D coll;
    private GameObject spell;

    private SpriteRenderer headSprite;
    private SpriteRenderer torsoSprite;
    private SpriteRenderer legsSprite;

    private float nextShotTimeStamp;
    private bool isDodging;
}

using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 10;

    [HideInInspector]
    public Vector3 Direction;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Direction * Speed;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Game over - player was hit.");
        Destroy(gameObject);
    }
}

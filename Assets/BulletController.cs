using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Game over - player was hit.");
        Destroy(gameObject);
    }
}

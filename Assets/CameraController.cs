using UnityEngine;

public class CameraController : MonoBehaviour {
	public Vector2 MaxXAndY;
	public Vector2 MinXAndY;

    private void FixedUpdate()
    {
		float targetX = Mathf.Clamp(transform.position.x, MinXAndY.x, MaxXAndY.x);
		float targetY = Mathf.Clamp(transform.position.y, MinXAndY.y, MaxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}

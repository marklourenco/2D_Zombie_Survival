using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float smoothTime = 0.3f;

    private Vector2 velocity = Vector2.zero;

    // (0, 0) = Vector2.zero
    // identity = Quaternion.identity
    // 1, 0, 0 
    // 0, 1, 0
    // 0, 0, 1

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            Vector2 playerPos = new Vector2(player.position.x, player.position.y);
            transform.position = Vector2.SmoothDamp(transform.position, playerPos, ref velocity, smoothTime);
        }
    }

    // Transform = (x, y, z)
}

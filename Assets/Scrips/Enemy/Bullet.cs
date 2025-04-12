using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2.5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}

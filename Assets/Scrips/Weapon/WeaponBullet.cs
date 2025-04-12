using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponBullet : MonoBehaviour
{
    public float speed = 5.0f;
    public int damage = 10;
    public float lifeTime = 2.5f;

    [Header("Piercing Ammo")]
    public bool piercingAmmo = false;
    public float hitCooldown = 1.0f;

    private Vector2 direction;
    private Dictionary<Collider2D, float> enemyHitTimestamps = new Dictionary<Collider2D, float>();

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        List<Collider2D> toRemove = new List<Collider2D>();
        foreach (var pair in enemyHitTimestamps)
        {
            if (Time.time - pair.Value >= hitCooldown)
            {
                toRemove.Add(pair.Key);
            }
        }
        foreach (var enemy in toRemove)
        {
            enemyHitTimestamps.Remove(enemy);
        }
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (enemyHitTimestamps.ContainsKey(collision))
            {
                return;
            }

            Debug.Log("Hit enemy");
            collision.GetComponent<Enemy>()?.TakeDamage(damage);
            enemyHitTimestamps[collision] = Time.time;

            if (!piercingAmmo)
            {
                Destroy(gameObject);
            }
        }
    }
}

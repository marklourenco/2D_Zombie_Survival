using UnityEngine;

public class RangedEnemy : EnemyBehavior
{
    public float stopDistance = 5.0f;
    public float speed = 3.0f;
    public GameObject bulletPrefab;
    public float fireRate = 1.0f;
    private float lastShotTime;

    protected override void Act()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)(dir * speed * Time.deltaTime);
        }
        else if (Time.time > lastShotTime + fireRate)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void Shoot()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().linearVelocity = dir * 5.0f;
    }
}

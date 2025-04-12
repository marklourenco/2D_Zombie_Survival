using UnityEngine;

public class MeleeEnemy : EnemyBehavior
{
    public float speed = 3.0f;
    public float attackRange = 1.0f;
    public float attackCooldown = 1.0f;
    public int damage = 10;
    public float lastAttackTime;

    protected override void Act()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            // BFS / DFS WALK SYSTEM

            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)(dir * speed * Time.deltaTime);
        }
        else if (Time.time > lastAttackTime + attackCooldown)
        {
            player.GetComponent<PlayerStats>()?.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }

    // DoDamage
    // attackRangeAttack
}

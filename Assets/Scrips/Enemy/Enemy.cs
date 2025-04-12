using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 20;

    public virtual void TakeDamage(int damage)
    {
        Debug.Log("Enemy took damage: " + damage);
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    // hp = hp - damage
    // hp -= damage

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}

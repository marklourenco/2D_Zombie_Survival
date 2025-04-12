using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{

    protected Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (player != null)
        {
            Act();
        }
    }

    protected abstract void Act();

    // define what the function is { what it do }
}

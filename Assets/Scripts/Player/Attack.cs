using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 1f;

    private Rigidbody2D rb;
    private Transform parentTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        parentTransform = transform.parent;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        rb.position = parentTransform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            DestroyObstacle destroyObstacle = other.GetComponent<DestroyObstacle>();
            if (destroyObstacle != null)
            {
                Vector3 hitPos = other.ClosestPoint(transform.position);
                destroyObstacle.DestroyTile(hitPos);
            }
        }

        // if (other.CompareTag("Enemy"))
        // {
        //     EnemyBehaviour enemyBehaviour = other.GetComponent<EnemyBehaviour>();
        //     if (enemyBehaviour != null)
        //     {
        //         enemyBehaviour.TakeDamage(damage);
        //     }
        // }
    }
}


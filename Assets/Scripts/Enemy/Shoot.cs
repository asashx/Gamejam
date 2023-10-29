using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage = 1f;
    public float speed = 10f;
    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 子弹发射方向
    public void SetSpeed(Vector2 direction)
    {
        direction.Normalize();
        rb.velocity = direction * speed;
    }
    
    // 碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Die();
        }
        
        // else if (other.CompareTag("Obstacle"))
        // {
        //     DestroyObstacle destroyObstacle = other.GetComponent<DestroyObstacle>();
        //     if (destroyObstacle != null)
        //     {
        //         destroyObstacle.DestroyTile(transform.position);
        //     }
        //     Die();
        // }
        //
        // else if (other.CompareTag("Enemy"))
        // {
        //     Die();
        //     Character character = other.GetComponent<Character>();
        //     if (character != null)
        //     {
        //         character.TakeDamage(damage);
        //     }
        // }
        
        if (other.CompareTag("Player"))
        {
            Die();
            Character character = other.GetComponent<Character>();
            if (character != null)
            {
                character.TakeDamage(damage);
            }
        }
    }

    // 子弹销毁
    public void Die()
    {
        ObjectPool.Instance.PushObject(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float damage = 1f;
    public float speed = 10f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 眼泪发射方向
    public void SetSpeed(Vector2 direction)
    {
        direction.Normalize();
        rb.velocity = direction * speed;
    }

    // 激活时设置存活时间和图层
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Player";
    }

    void Update()
    {
        
    }

    // 碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Die();
        }
        // else if (other.CompareTag("Enemy"))
        // {
        //     Die();
        //     EnemyBehaviour enemyBehaviour = other.GetComponent<EnemyBehaviour>();
        //     if (enemyBehaviour != null)
        //     {
        //         enemyBehaviour.TakeDamage(damage);
        //     }
        // }
    }

    // 眼泪销毁
    public void Die()
    {
        ObjectPool.Instance.PushObject(gameObject);
    }
}

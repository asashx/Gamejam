using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    public string essenceName;
    public GameObject experience;
    public PlayerBar playerBar;
    public float experienceValue = 1f;

    private void Awake()
    {   
        experience = GameObject.Find("Experience");
        playerBar = experience.GetComponent<PlayerBar>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.AbsorbAnim();
                player.AbsorbEssence(essenceName);
            }
            if (playerBar != null) // 检查是否为空
            {
                playerBar.AddExperience(experienceValue); // 触发事件并传递经验值
            }
            Destroy(gameObject);
        }
    }
}

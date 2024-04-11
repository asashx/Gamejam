using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Image bossHealth;
    public GameObject boss;
    private Character bossCharacter; // 用于保存获取的 Character 脚本引用
    public float lerpSpeed = 3;
    public float currentHealth;
    public float maxHealth = 30 ;
    public float healthFillAmount;

    private void Awake()
    {
        bossCharacter = boss.GetComponent<Character>();
        maxHealth = bossCharacter.maxHealth;
    }

    private void Update()
    {
        OnHealthChange();
        currentHealth = bossCharacter.currentHealth;
    }
    

    private void OnHealthChange()
    {
        // 计算经验条的填充比例
        healthFillAmount = (currentHealth / maxHealth);
        Debug.Log("执行");
        bossHealth.fillAmount = Mathf.Lerp(bossHealth.fillAmount, healthFillAmount, lerpSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("基础属性")] 
    public float maxHealth;
    public float currentHealth;
    public float damage;

    [Header("动画")]
    public Animator anim;

    public bool isHurt = false;
    
    [Header("受伤无敌")] 
    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;

    public UnityEvent<Transform> OnTakeDamage;//直接调用
    public UnityEvent OnDie;//直接调用
    
    void Start()
    {
        currentHealth = maxHealth; //设置生命值
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
            {
                invulnerable = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (invulnerable)
            return;
        
        //Debug.Log(attacker.damage);
        if (currentHealth - damage > 0)
        {   
            currentHealth -= damage; //设置生命的削减
            anim.SetTrigger("isHurt");
            TriggerInvulnerable();
            //执行受伤
        }
        else
        {
            currentHealth = 0;
            //触发死亡
            OnDie?.Invoke();
        }
    }

    public void TriggerInvulnerable()//计算无敌时间
    {
        if (!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}

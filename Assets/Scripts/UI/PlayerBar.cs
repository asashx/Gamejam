using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBar : MonoBehaviour
{   
    public Image experienceIamge;//传入UI部分
    //public Character character;
    public float lerpSpeed = 3;
    public float currentExperience = 0;
    public float maxExperience = 4; // 假设最大经验值为4
    public float level = 1;
    
    private void Start()
    {
        //character = GetComponent<Character>();
    }

    private void Update()
    {
        //OnHealthChange();
        OnExperienceChange();
    }

    // public void OnHealthChange()
    // {   
    //     //使用lerpSpeed使得血条的变化显得更加丝滑
    //     healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount,character.currentHealth / character.maxHealth,lerpSpeed * Time.deltaTime);
    // }
    
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void AddExperience(float experienceAmount)
    {
        currentExperience += experienceAmount;
        currentExperience = Mathf.Clamp(currentExperience, 0, maxExperience); // 确保经验值不超过最大值
        // 如果经验条满了，执行升级操作
        if (currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }
    
    private void LevelUp()
    {
        // 增加等级
        level++;
        Debug.Log("Level Up! New Level: " + level);

        // 重置经验条
        currentExperience = 0;

        // 假设每次升级后最大经验值也会增加
        //maxExperience += 20;
        
    }
    
    
    public void OnExperienceChange()
    {   
        // 计算经验条的填充比例
        float experienceFillAmount = currentExperience / maxExperience;
        experienceIamge.fillAmount = Mathf.Lerp(experienceIamge.fillAmount, experienceFillAmount, lerpSpeed * Time.deltaTime);
    }
    
}

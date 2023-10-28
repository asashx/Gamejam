using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBar : MonoBehaviour
{   
    public Image healthImage;
    public Image experienceIamgeC;
    public Image experienceIamgeF;//传入UI部分
    public Character character;
    public float lerpSpeed = 3;
    public float currentExperienceF = 0;
    public float maxExperienceF = 100; // 假设最大经验值为100
    public float currentExperienceC = 0;
    public float maxExperienceC = 100; // 假设最大经验值为100

    private void Start()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        OnHealthChange();
        OnExperienceChangeF();
    }

    public void OnHealthChange()
    {   
        //使用lerpSpeed使得血条的变化显得更加丝滑
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount,character.currentHealth / character.maxHealth,lerpSpeed * Time.deltaTime);
    }
    
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void AddExperienceF(float experienceAmount)
    {
        currentExperienceF += experienceAmount;
        currentExperienceF = Mathf.Clamp(currentExperienceF, 0, maxExperienceF); // 确保经验值不超过最大值
    }
    
    public void AddExperienceC(float experienceAmount)
    {
        currentExperienceF += experienceAmount;
        currentExperienceF = Mathf.Clamp(currentExperienceF, 0, maxExperienceF); // 确保经验值不超过最大值
    }
    public void OnExperienceChangeF()
    {   
        // 计算经验条的填充比例
        float experienceFillAmount = currentExperienceF / maxExperienceF;
        experienceIamgeF.fillAmount = Mathf.Lerp(experienceIamgeF.fillAmount, experienceFillAmount, lerpSpeed * Time.deltaTime);
    }
    
    public void OnExperienceChangeC()
    {   
        // 计算经验条的填充比例
        float experienceFillAmount = currentExperienceC / maxExperienceC;
        experienceIamgeC.fillAmount = Mathf.Lerp(experienceIamgeC.fillAmount, experienceFillAmount, lerpSpeed * Time.deltaTime);
    }
}

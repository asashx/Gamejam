using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public float playerHealth;
    public float playerExperience;
    
    public static Data Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    public void SaveData1(float playerHealth)
    {
        PlayerPrefs.SetFloat("currentHealth", playerHealth);
        //PlayerPrefs.SetFloat("Experience", playerExperience);
        // 保存其他属性
    }
    
    public void SaveData2(float playerExperience)
    {
        //PlayerPrefs.SetFloat("currentHealth", playerHealth);
        PlayerPrefs.SetFloat("currentExperience", playerExperience);
        // 保存其他属性
    }
    public void LoadData()
    {
        playerHealth = PlayerPrefs.GetFloat("currentHealth");
        playerExperience = PlayerPrefs.GetFloat("currentExperience");
        // 加载其他属性
    }

}

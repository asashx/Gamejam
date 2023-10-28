using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSecond : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            ObjectPool.Instance.Clear(); // 初始化对象池
            SceneManager.LoadScene("Second"); //把当前活动场景的属性拿出，+1即到下一个场景
            
        }
    }
}

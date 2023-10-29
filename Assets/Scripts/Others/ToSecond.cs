using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSecond : MonoBehaviour
{   
    //public GameObject dataManager;
    //public Data data;

    private void Awake()
    {
        // dataManager = GameObject.Find("DataManager");
        // data = dataManager.GetComponent<Data>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            ObjectPool.Instance.Clear(); // 初始化对象池
            SceneManager.LoadScene("Second"); //把当前活动场景的属性拿出，+1即到下一个场景
            // 加载属性，通常在游戏启动时
           // data.LoadData();
        }
    }
}

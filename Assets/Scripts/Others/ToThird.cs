using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToThird : MonoBehaviour
{
    // public GameObject dataManager;
    // public Data data;

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
            Debug.Log("111");
            SceneManager.LoadScene("Third"); 
            // 加载属性，通常在游戏启动时
            //data.LoadData();
        }
    }
}

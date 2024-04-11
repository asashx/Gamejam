using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCheck : MonoBehaviour
{
    // Start is called before the first frame update
    //private BoxCollider2D mapCheck;
    private Scene currentScene;
    private string currentSceneName;
    public Rigidbody2D rb;
    
    void Start()
    {
        // // 获取游戏对象所在的场景
        // currentScene = gameObject.scene;
        // // 获取当前场景的名称
        // currentSceneName = currentScene.name;    
        // 获取当前场景的名称
        currentSceneName = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {   
            Debug.Log("2");
            ObjectPool.Instance.Clear(); // 初始化对象池
            SceneManager.LoadScene(currentSceneName);
        }
        
    }
}

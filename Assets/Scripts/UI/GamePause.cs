using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseMasks;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button homeButton;
    private bool isPaused = false;
    
    private void Awake()
    {
        PauseMasks.SetActive(false);//先隐藏
        exitButton.onClick.AddListener(OnexitButtonClick);//监听
        restartButton.onClick.AddListener(OnrestartButtonClick);
        backButton.onClick.AddListener(OnbackButtonClick);
        homeButton.onClick.AddListener(OnhomeButtonClick);
    }
    
    private void Update()
    {
        // 检测是否按下ESC键来切换暂停状态
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    //两次按ESC
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // 暂停游戏时间
            PauseMasks.SetActive(true); // 启用暂停菜单
        }
        else
        {
            Time.timeScale = 1f; // 恢复游戏时间
            PauseMasks.SetActive(false); // 禁用暂停菜单
        }
    }
    
    private void OnexitButtonClick()
    {
        //当点击退出
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    
    private void OnrestartButtonClick()
    {
        SceneManager.LoadScene("First");
        Time.timeScale = 1f; // 恢复游戏时间
        ObjectPool.Instance.Clear(); // 初始化对象池
    }
   
    private void OnbackButtonClick()
    {
            ResumeGame();//恢复游戏
    }
    
    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // 恢复游戏时间
        PauseMasks.SetActive(false); // 禁用暂停菜单
    }
    
    private void OnhomeButtonClick()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f; // 恢复游戏时间
        ObjectPool.Instance.Clear(); // 初始化对象池
    }
}

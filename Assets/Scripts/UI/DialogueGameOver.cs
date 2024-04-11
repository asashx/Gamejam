using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueGameOver : MonoBehaviour
{
    [Header("UI组件")]
    public TextMeshProUGUI textLabel; 
    public GameObject gameoverImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFromFile(textFile);
        gameoverImage.SetActive(false);
    }

    private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Return) && index == textList.Count)
        // {
        //     gameObject.SetActive(false);
        //     index = 0;
        //     //gameoverImage.SetActive(true);
        //     return;
        // }
        // if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     textLabel.text = textList[index];
        //     index++;
        // }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index < textList.Count)
            {
                textLabel.text = textList[index];
                index++;
            }
            else
            {
                // 对话结束，显示gameoverImage
                gameoverImage.SetActive(true);
                gameObject.SetActive(false); // 隐藏对话UI
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }
}

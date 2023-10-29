using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talk : MonoBehaviour
{
    public Text dialogText;
    public float textSpeed = 0.05f; // 文字弹出速度
    private string fullText;
    private int currentCharacter;

    private void Start()
    {
        fullText = dialogText.text;
        dialogText.text = "";//清空文本
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        while (currentCharacter < fullText.Length)
        {
            dialogText.text += fullText[currentCharacter];
            currentCharacter++;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

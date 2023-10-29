using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public GameObject Hearts;
   public GameObject player;
   private Character playerCharacter; // 用于保存获取的 Character 脚本引用
   // public GameObject dataManager;
   // public Data data;
   private void Awake()
   {
	   // 如果你不需要在 Awake 中获取 Character 脚本，你可以注释掉下面的行：
	    playerCharacter = player.GetComponent<Character>();
   }

   private void Start()
   {
	   
   }

   private void Update()
   {	
	   
	   if (player != null)
	   {
		   float currentHealth = playerCharacter.currentHealth;
		   //data.SaveData1(currentHealth);
		   Debug.Log("Health:" + playerCharacter.currentHealth);
		   ChangeHealth(currentHealth);
	   }
   }

   void ChangeHealth(float currentHealth)	
   {		
			//Debug.Log("startHealth:" + player.Character.currentHealth);
			if (currentHealth == 5f)
			{
				Hearts.transform.Find("Heart5").Find("None5").gameObject.SetActive(true);
				Hearts.transform.Find("Heart5").Find("Full5").gameObject.SetActive(true);
				Hearts.transform.Find("Heart4").Find("None4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart4").Find("Full4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("None3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("Full3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("None2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("Full2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("None1").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("Full1").gameObject.SetActive(true);
			}

			if (currentHealth == 4f)
			{
				Hearts.transform.Find("Heart5").Find("None5").gameObject.SetActive(true);
				Hearts.transform.Find("Heart5").Find("Full5").gameObject.SetActive(false);
				Hearts.transform.Find("Heart4").Find("None4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart4").Find("Full4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("None3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("Full3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("None2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("Full2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("None1").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("Full1").gameObject.SetActive(true);
			}
			
			if (currentHealth == 3f)
			{
				Hearts.transform.Find("Heart5").Find("None5").gameObject.SetActive(true);
				Hearts.transform.Find("Heart5").Find("Full5").gameObject.SetActive(false);
				Hearts.transform.Find("Heart4").Find("None4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart4").Find("Full4").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("None3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("Full3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("None2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("Full2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("None1").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("Full1").gameObject.SetActive(true);
			}
			
			if (currentHealth == 2f)
			{
				Hearts.transform.Find("Heart5").Find("None5").gameObject.SetActive(true);
				Hearts.transform.Find("Heart5").Find("Full5").gameObject.SetActive(false);
				Hearts.transform.Find("Heart4").Find("None4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart4").Find("Full4").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("None3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("Full3").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("None2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("Full2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("None1").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("Full1").gameObject.SetActive(true);
			}
			
			if (currentHealth == 1f)
			{
				Hearts.transform.Find("Heart5").Find("None5").gameObject.SetActive(true);
				Hearts.transform.Find("Heart5").Find("Full5").gameObject.SetActive(false);
				Hearts.transform.Find("Heart4").Find("None4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart4").Find("Full4").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("None3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("Full3").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("None2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("Full2").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("None1").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("Full1").gameObject.SetActive(true);
			}
			
			if (currentHealth == 0f)
			{
				Hearts.transform.Find("Heart5").Find("None5").gameObject.SetActive(true);
				Hearts.transform.Find("Heart5").Find("Full5").gameObject.SetActive(false);
				Hearts.transform.Find("Heart4").Find("None4").gameObject.SetActive(true);
				Hearts.transform.Find("Heart4").Find("Full4").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("None3").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("Full3").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("None2").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("Full2").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("None1").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("Full1").gameObject.SetActive(false);
			}
			// 保存属性，例如当玩家升级时
			

		
   }
}

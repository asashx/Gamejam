using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public GameObject Hearts;
   public Player player;

   private void Awake()
   {
	   player = GetComponent<Player>();
   }

   private void Update()
   {
	   if (player != null)
	   {
		   float currentHealth = player.currentHealth;
		   Debug.Log("Health:" + player.currentHealth);
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
			
		
   }
}

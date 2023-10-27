using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFight : Enemy
{
   
   void Start()
   {
      
   }

   void Update()
   {
      
   }

   public override void Move()
   {
      base.Move();
      anim.SetBool("Move",true);//这里覆写了之后加上了播放走动动画的步骤
   }
}


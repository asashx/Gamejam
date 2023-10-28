using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePatrolState : BaseState
{
    //private BaseState _baseStateImplementation;
    public override void OnEnter(CloseEnemy enemy)
    {
        //_baseStateImplementation.OnEnter(CloseEnemy enemy);
        currentEnemy = enemy;
        currentEnemy.currentSpeed = currentEnemy.normalSpeed;
    }

    public override void LogicUpdate()
    {
       // _baseStateImplementation.LogicUpdate();
       if (currentEnemy.FoundPlayer())
       {
           currentEnemy.SwitchState(NPCState.Chase);
       }
       if ((!currentEnemy.physicCheck.onRightGround && currentEnemy.faceDir.x > 0)  || (!currentEnemy.physicCheck.onLeftGround && currentEnemy.faceDir.x < 0)|| !currentEnemy.physicCheck.isGround || (currentEnemy.physicCheck.touchRightWall && currentEnemy.faceDir.x > 0) ||(currentEnemy.physicCheck.touchLeftWall && currentEnemy.faceDir.x < 0))
       {      
           Debug.Log("撞墙");
           currentEnemy.wait = true;
           //currentEnemy.anim.SetBool("Move",false);
       }
       else
       {
           currentEnemy.wait = false;
           //currentEnemy.anim.SetBool("Move",true);
       }
       
    }

    public override void PhysicsUpdate()
    {
        //_baseStateImplementation.PhysicsUpdate();
    }

    public override void OnExit()
    {
        //_baseStateImplementation.OnExit();
        //currentEnemy.anim.Setbool("Move", false);
    }
}

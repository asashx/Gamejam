using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChaseState : BaseState
{
    public override void OnEnter(CloseEnemy enemy)
    {
        //throw new System.NotImplementedException();
        currentEnemy = enemy;
        currentEnemy.currentSpeed = currentEnemy.chaseSpeed;
        //currentEnemy.anim.SetBool("run",true);
    }

    public override void LogicUpdate()
    {
        //throw new System.NotImplementedException();
        if (currentEnemy.lostTimeCounter <= 0)
        {
            currentEnemy.SwitchState(NPCState.Patrol);
        }
        if (!currentEnemy.physicCheck.isGround || (currentEnemy.physicCheck.touchRightWall && currentEnemy.faceDir.x > 0) ||(currentEnemy.physicCheck.touchLeftWall && currentEnemy.faceDir.x < 0))
        {
            currentEnemy.transform.localScale = new Vector3(currentEnemy.faceDir.x, 1, 1);
            //currentEnemy.anim.SetBool("Move",false);
        }
        else
        {
            //currentEnemy.anim.SetBool("Move",true);
        }
    }

    public override void PhysicsUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        //throw new System.NotImplementedException();
        currentEnemy.lostTimeCounter = currentEnemy.lostTime;
        //currentEnemy.anim.SetBool("run",false);
    }
}

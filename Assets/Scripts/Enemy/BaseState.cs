using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{   
    //将其作为抽象基类
    protected CloseEnemy currentEnemy;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public abstract void OnEnter(CloseEnemy enemy);
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();
    public abstract void OnExit();

}

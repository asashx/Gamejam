using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CloseEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    protected Animator anim;
    private CapsuleCollider2D coll;
    public PhysicCheck physicCheck;//调用脚本，隐藏
    
    [Header("基本参数")] 
    public float normalSpeed;//基础速度
    public float chaseSpeed;//追击速度
    public float currentSpeed;//当前的速度，直接用两个速度进行赋值
    public Vector3 faceDir;//面朝对象
    public Transform attacker;//被攻击的对象
    public float hurtForce;
    public float experienceValue;
    public Character character;
    
    [Header("检测")]
    public Vector2 centerOffset;
    public Vector2 checkSize;
    public float checkDistance;
    public LayerMask attackLayer;
    
    [Header("状态")] 
    public bool Hurt;
    public bool Dead;
    
    [Header("计时器")] 
    public bool wait = false;
    public float waitTimeCounter;
    public float waitTime;
    public float lostTime;
    public float lostTimeCounter;
    
    [Header("吸收")]
    public GameObject meleeEssencePrefab;
    public PlayerBar playerBar;

    private BaseState currentState;
    protected BaseState patrolState;
    protected BaseState chaseState;//设置状态
    
    void Awake()
    {
        Hurt = false;
        Dead = false;
        rb = GetComponent<Rigidbody2D>();
        playerBar = GetComponent<PlayerBar>();
        physicCheck = GetComponent<PhysicCheck>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();//获取组件
        character = GetComponent<Character>();
        currentSpeed = normalSpeed;//速度
        waitTimeCounter = waitTime;//时间
        patrolState = new ClosePatrolState();
        chaseState = new CloseChaseState();
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        currentState = patrolState;
        currentState.OnEnter(this);
    }

    private void Update()
    {
        //Debug.Log("HUH");
        faceDir = new Vector3(-transform.localScale.x, 0, 0); //获取敌人的面朝方式

        TimeCounter();
        currentState.LogicUpdate();

        if (character.Hurt)
        {
            OnTakeDamage();
        }
}

    private void FixedUpdate()
    {   
        //Debug.Log("启动了");
        if (!Hurt && !Dead && !wait )
        {
            Move();//执行自动移动
            currentState.PhysicsUpdate();
        }
    }

    public void OnDisable()
    {
        currentState.OnExit();
    }

    public virtual void Move()//希望可以复写
    {   
        Debug.Log("移动");
        rb.velocity = new Vector2(currentSpeed *  faceDir.x, rb.velocity.y);//设置了敌人的移动
    }
    
    public void TimeCounter()//计时器
    {   
        if (wait)
        {   
            Debug.Log("wait");
            rb.velocity = Vector2.zero; 
            waitTimeCounter -= Time.deltaTime;
            if (waitTimeCounter <= 0)
            {   
                //Debug.Log("进行改变");
                wait = false;
                waitTimeCounter = waitTime;
                transform.localScale = new Vector3(faceDir.x, 1, 1);
                
            }
        }

        if (!FoundPlayer() && lostTimeCounter > 0)
        {
            lostTimeCounter -= Time.deltaTime;
            
        }
        else
        {
            lostTimeCounter = lostTime;
        }//检测丢失敌人后的时间
    }

    public bool FoundPlayer()////检测面朝方向是否有玩家
    {
        return Physics2D.BoxCast(transform.position + (Vector3)centerOffset, checkSize, 0, faceDir, checkDistance, attackLayer);
        
    }

    public void SwitchState(NPCState state)//通过枚举进行状态切换
    {
        var newState = state switch
        {
            NPCState.Patrol => patrolState,
            NPCState.Chase => chaseState,
            _ => null
        };
        
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter(this);
    }
    
    #region 事件执行部分
    public void OnTakeDamage()
    {   
        //受击转身
        
        // if (attacker.position.x - transform.position.x > 0)
        // {
        //     transform.localScale = new Vector3(1,1, 1);
        // }
        // if (attacker.position.x - transform.position.x < 0)
        // {
        //     transform.localScale = new Vector3(1,1, 1);
        // }
        //受伤之后会造成一定的击退效果
        Hurt = true;
        //anim.SetTrigger("Hurt");//播放受击动画
        Vector2 dir = new Vector2(Mathf.Abs(transform.position.x - attacker.position.x), 0).normalized;
        rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y);
        StartCoroutine(OnHurt(dir));//使用携程进行一个动作切换的时间间隔
    }

    private IEnumerator OnHurt(Vector2 dir)
    {
        rb.AddForce(dir * hurtForce,ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(0.3f);
        Hurt = false;
        character.Hurt = false;
    }

    public void OnDie()
    {   
        Debug.Log("dead");
        gameObject.layer = 5;//这里的第五个图层之后设置为忽略的图层，这里面的物体不会与角色产生碰撞
        anim.SetBool("Dead",true);
        Dead = true;
        DestroyObject();
    }

    public void DestroyObject()
    {   
        if (meleeEssencePrefab != null)
        {
            Instantiate(meleeEssencePrefab, transform.position, Quaternion.identity); // 生成ShootEssence预制体
        }
        if (playerBar != null) // 检查是否为空
        {
            playerBar.AddExperienceF(experienceValue); // 触发事件并传递经验值
        }
        Destroy(this.gameObject);//播放死亡动画后摧毁物体
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)centerOffset + new Vector3(checkDistance * -transform.localScale.x,0),0.2f);
    }
}
 
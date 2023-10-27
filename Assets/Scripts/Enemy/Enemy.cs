using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    //protected Animator anim;
    private CapsuleCollider2D coll;
    
    [Header("基本参数")] 
    public float normalSpeed;//基础速度
    public float chaseSpeed;//追击速度
    public float currentSpeed;//当前的速度，直接用两个速度进行赋值
    public Vector3 faceDir;//面朝对象
    public Transform attacker;//被攻击的对象
    public float hurtForce;
    [Header("检测参数")] 
    public Vector2 leftOffset;//左方检测
    public bool manual;//可以自动进行检测bool值
    public Vector2 rightOffset;//右方检测
    public float checkRaduis;//检测的基础范围
    public LayerMask groundLayer;
    
    [Header("状态")] 
    public bool touchLeftWall;//移动怪物是否触碰左墙
    public bool touchRightWall; //移动怪物是否触碰右墙
    public bool isHurt;
    public bool isDead;
    
    [Header("计时器")] 
    public bool wait;
    public float waitTimeCounter;
    public float waitTime;
    
    void Awake()
    {
        isHurt = false;
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();//获取组件
        currentSpeed = normalSpeed;
        if (!manual)
        {   
            //判断下左右的检测范围
            rightOffset = new Vector2((coll.bounds.size.x + coll.offset.x)/2,coll.bounds.size.y/2);
            leftOffset = new Vector2(-(coll.bounds.size.x + coll.offset.x)/2,coll.bounds.size.y/2);
        }

        waitTimeCounter = waitTime;
    }

    void Start()
    {
        
    }
    
    private void Update()
    {   
        Debug.Log("为什么不运行");
        faceDir = new Vector3(transform.localScale.x,0,0);//获取敌人的面朝方式
    }

    private void FixedUpdate()
    {   
        Debug.Log("启动了");
        if (!isHurt && !isDead)
        {
            Move();
            Check();
        }
    }

    public virtual void Move()//希望可以复写
    {   
        Debug.Log("移动");
        rb.velocity = new Vector2(currentSpeed *  transform.localScale.x, rb.velocity.y);//设置了敌人的移动
    }

    public void Check()
    {   
        
        
        //墙体判断,左右墙
        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRaduis, groundLayer);
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRaduis, groundLayer);
        if ((touchLeftWall && faceDir.x > 0)|| (touchRightWall && faceDir.x < 0) )
        {   
            Debug.Log("撞墙");
            wait = true;
            //anim.SetBool("Move",false);
        }
        TimeCounter();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRaduis);
    }

    public void TimeCounter()
    {   
        if (wait)
        {
            waitTimeCounter -= Time.deltaTime;
            if (waitTimeCounter <= 0)
            {   
                Debug.Log("进行改变");
                wait = false;
                waitTimeCounter = waitTime;
                transform.localScale = new Vector3(-faceDir.x, 1, 1);
            }
        }
    }

    public void OnTakeDamage(Transform attckTrans)
    {   
        //受击转身
        attacker = attckTrans;
        
        if (attckTrans.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (attckTrans.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //受伤之后会造成一定的击退效果
        isHurt = true;
        //anim.SetTrigger("hurt");//播放受击动画
        Vector2 dir = new Vector2(transform.position.x - attckTrans.position.x, 0).normalized;

        StartCoroutine(OnHurt(dir));//使用携程进行一个动作切换的时间间隔
    }

    private IEnumerator OnHurt(Vector2 dir)
    {
        rb.AddForce(dir * hurtForce,ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        isHurt = false;
    }

    public void OnDie()
    {
        gameObject.layer = 2;//这里的第二个图层之后设置为忽略的图层，这里面的物体不会与角色产生碰撞
        //anim.SetBool("Dead",true);
        isDead = true;
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);//播放死亡动画后摧毁物体
    }
}
 
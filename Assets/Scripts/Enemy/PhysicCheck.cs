using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicCheck : MonoBehaviour
{   
    private CapsuleCollider2D coll;
    [Header("状态")]
    public bool touchLeftWall;//移动怪物是否触碰左墙
    public bool touchRightWall; //移动怪物是否触碰右墙
    public bool isGround;
    public bool onLeftGround;
    public bool onRightGround;
    
    [Header("检测参数")] 
    public Vector2 leftOffset;//左方检测
    public Vector2 rightOffset;//右方检测
    public Vector2 bottomOffset;
    public Vector2 bottmOffsetLeft;
    public Vector2 bottmOffsetRight;
    public bool manual;//可以自动进行检测bool值
    public float checkRaduis;//检测的基础范围
    public LayerMask groundLayer;
    
    void Awake()
    {
        // isHurt = false;
        // isDead = false;
        //anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();//获取组件
        // if (!manual)
        // {   
        //     //判断下左右的检测范围
        //     rightOffset = new Vector2((coll.bounds.size.x + coll.offset.x)/2,coll.bounds.size.y/2);
        //     leftOffset = new Vector2(-(coll.bounds.size.x + coll.offset.x)/2,coll.bounds.size.y/2);
        // }

        //waitTimeCounter = waitTime;
    }
    
    void Start()
    {
        
    }


    void Update()
    {
        Check();
    }

    public void Check()
    {   
        
        //是否在地面判断,左右地面的判断
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);
        onLeftGround = Physics2D.OverlapCircle((Vector2)transform.position + bottmOffsetLeft, checkRaduis, groundLayer);
        onRightGround = Physics2D.OverlapCircle((Vector2)transform.position + bottmOffsetRight, checkRaduis, groundLayer);
        //墙体判断,左右墙
        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRaduis, groundLayer);
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRaduis, groundLayer);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset,checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + bottmOffsetLeft, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + bottmOffsetRight, checkRaduis);
    }
}

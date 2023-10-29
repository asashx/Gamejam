using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarEnemy2 : MonoBehaviour
{      
    private Rigidbody2D rb;
    
    [Header("基本参数")] 
    public Vector3 faceDir;//面朝对象
    public Transform attacker;//被攻击的对象
    public Transform shootPoint;//射击出发点 
    public Transform target;//射击目标
    public float hurtForce;//击退
    //public float damage = 1f;//伤害
    public float hitRate = 0.7f;//攻击间隔
    private float _lastHit;
    public float experienceValue;
    public GameObject bulletPrefab; //子弹
    private Animator _animator;
    public float attackRange;//判断射击范围
    public Character character;

    [Header("吸收")] 
    public GameObject shootEssencePrefab;
    public PlayerBar playerBar;
    
    [Header("状态")] 
    public bool Hurt;//手上
    public bool Dead;//死亡
    
    protected void Start()
    {
        _animator = GetComponent<Animator>();
        playerBar = GetComponent<PlayerBar>();
        character = GetComponent<Character>();
        shootPoint = transform.Find("ShootPoint");
        ObjectPool objectPool = ObjectPool.Instance;//查看对象池
        if (objectPool == null)
        {
            Debug.LogError("ObjectPool.Instance is null!");
        }
    }
    
    void Update()
    {
        if (target == null)
        {
            return;
        }
        
        // 计算目标与敌人的距离
        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= attackRange)
        {
            if (Time.time > _lastHit + 1 / hitRate)
            {
                Shoot();
                _lastHit = Time.time;
            }
        }

        faceDir.x = -(target.position.x - transform.position.x)/(Mathf.Abs(target.position.x - transform.position.x));
        transform.localScale = new Vector3(faceDir.x,1,1);

        if (character.Hurt)
        {
            OnTakeDamage();
        }

    }
    
    private void Shoot()
    {
        if (target == null)
        {
            return;
        }

        Vector3 shootDirection = (target.position - transform.position).normalized;
        // 创建子弹并设置位置为ShootPoint的位置
        GameObject bullet1 = ObjectPool.Instance.GetObject(bulletPrefab); 
        bullet1.transform.position = shootPoint.position; 
        bullet1.transform.localScale = new Vector3(-faceDir.x,1,1);
        // 设置子弹速度
        bullet1.GetComponent<Bullet>().SetSpeed(shootDirection);
    
        // 创建第二颗子弹，添加角度偏移
        float bulletSpreadAngle = 10.0f; // 角度偏移，你可以根据需要调整
        Quaternion bulletRotation = Quaternion.Euler(0, 0, bulletSpreadAngle);
        
        // 计算第二颗子弹的速度方向，朝向目标的方向加上角度偏移
        Vector3 secondBulletDirection = bulletRotation * shootDirection;
        
        // 创建第二颗子弹并设置位置为ShootPoint的位置
        GameObject bullet2 = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet2.transform.position = shootPoint.position;
        bullet2.transform.localScale = new Vector3(-faceDir.x,1,1);
        // 设置子弹速度
        bullet2.GetComponent<Bullet>().SetSpeed(secondBulletDirection);
    }
    
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
        //rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y);
        StartCoroutine(OnHurt(dir));//使用携程进行一个动作切换的时间间隔
    }

    private IEnumerator OnHurt(Vector2 dir)
    {
        //rb.AddForce(dir * hurtForce,ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        Hurt = false;
        character.Hurt = false;
    }
    
    public void OnDie()
    {
        gameObject.layer = 5;//这里的第五个图层之后设置为忽略的图层，这里面的物体不会与角色产生碰撞
        _animator.SetBool("Dead",true);
        Dead = true;
        DestroyObject();
    }
    
    public void DestroyObject()
    {
        if (shootEssencePrefab != null)
        {
            Instantiate(shootEssencePrefab, transform.position, Quaternion.identity); // 生成ShootEssence预制体
        }
        
        if (playerBar != null) // 检查是否为空
        {
            playerBar.AddExperienceF(experienceValue); // 触发事件并传递经验值
        }
        Destroy(this.gameObject);//播放死亡动画后摧毁物体
    }
}

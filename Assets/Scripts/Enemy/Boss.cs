using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D rb;
    private float shootCount = 1; 
    [Header("基本参数")] 
    public Transform attacker;//被攻击的对象
    public Transform shootPoint1;//射击出发点 
    public Transform target;//射击目标
    public float damage = 1f;//伤害
    //private float _lastHit;上次攻击的时间
    public float experienceValue;
    public GameObject bulletPrefab; //子弹
    public GameObject specialbulletPrefab; //追踪子弹
    private Animator _animator;
    public float shootRange;//判断射击范围
    public float hitRange;//判断突刺范围
    [Header("吸收")] 
    public PlayerBar playerBar;
    
    [Header("状态")] 
    public bool isHurt;//受伤
    public bool isDead;//死亡
    
    protected void Start()
    {
        _animator = GetComponent<Animator>();
        playerBar = GetComponent<PlayerBar>();
        shootPoint1 = transform.Find("ShootPoint");
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

        if (distanceToTarget <= shootRange)
        {
                Debug.Log("HELLO");
                Shoot();
                //_lastHit = Time.time;
        }
        else if (distanceToTarget <= hitRange)
        {
            
                 Shoot();
                 Hit();
                 //_lastHit = Time.time;
        }
    }
    
    #region 尝试编写三段弹幕
    private IEnumerator DelayedShoot(Vector3 direction, float delay)
    {
        float Count = 0;
        yield return new WaitForSeconds(delay);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);// 创建子弹并设置位置为ShootPoint的位置
        GameObject specialbullet = ObjectPool.Instance.GetObject(specialbulletPrefab);//追踪子弹,追不了一点
        bullet.transform.position = shootPoint1.position;
        specialbullet.transform.position = shootPoint1.position;
        bullet.GetComponent<Bullet>().SetSpeed(direction);
        
        
    }
    
    private void Shoot()
    {
        if (target == null)
        {
            return;
        }

        if (shootCount == 1)
        {      
            Vector3 shootDirection = (target.position - shootPoint1.position).normalized;//确认方向
            float delayBetweenBullets1 = 0.5f; // 第一轮子弹间0.05秒的间隔
            float delayBetewwnCount = 3f;//每轮的间隔
            float delayBetweenBullets2 = 1f;
            
            // 创建第二颗子弹，添加角度偏移
            float bulletSpreadAngle1 = 10.0f; // 角度偏移
            Quaternion bulletRotation1 = Quaternion.Euler(0, 0, bulletSpreadAngle1);
            // 计算第二颗子弹的速度方向，朝向目标的方向加上角度偏移
            Vector3 secondBulletDirection = bulletRotation1 * shootDirection;
            
            // 创建第三颗子弹，添加角度偏移
            float bulletSpreadAngle2 = 20.0f; // 角度偏移
            Quaternion bulletRotation2 = Quaternion.Euler(0, 0, bulletSpreadAngle2);
            // 计算第三颗子弹的速度方向，朝向目标的方向加上角度偏移
            Vector3 thirdBulletDirection = bulletRotation2 * shootDirection;
            
            // 创建第四颗子弹，添加角度偏移
            float bulletSpreadAngle3 = 30.0f; // 角度偏移
            Quaternion bulletRotation3 = Quaternion.Euler(0, 0, bulletSpreadAngle3);
            // 计算第四颗子弹的速度方向，朝向目标的方向加上角度偏移
            Vector3 fourthBulletDirection = bulletRotation3 * shootDirection;
            
            // 创建第五颗子弹，添加角度偏移
            float bulletSpreadAngle4 = 40.0f; // 角度偏移，你可以根据需要调整
            Quaternion bulletRotation4 = Quaternion.Euler(0, 0, bulletSpreadAngle4);
            // 计算第五颗子弹的速度方向，朝向目标的方向加上角度偏移
            Vector3 fivethBulletDirection = bulletRotation4 * shootDirection;
            
            // 创建第六颗子弹，添加角度偏移
            float bulletSpreadAngle5 = 50.0f; // 角度偏移，你可以根据需要调整
            Quaternion bulletRotation5 = Quaternion.Euler(0, 0, bulletSpreadAngle5);
            // 计算第六颗子弹的速度方向，朝向目标的方向加上角度偏移
            Vector3 sixthBulletDirection = bulletRotation5 * shootDirection;
            
            
            // 第一轮，依次发射子弹，每颗之间间隔0.05秒
            StartCoroutine(DelayedShoot(shootDirection, 0 * delayBetweenBullets1));
            StartCoroutine(DelayedShoot(shootDirection, 1 * delayBetweenBullets1));
            StartCoroutine(DelayedShoot(shootDirection, 2 * delayBetweenBullets1));
            //一二轮间隔2s
            StartCoroutine(DelayedShoot(secondBulletDirection, 2 * delayBetweenBullets1 + delayBetewwnCount));
            StartCoroutine(DelayedShoot(thirdBulletDirection, 2 * delayBetweenBullets1 + delayBetewwnCount + 1 * delayBetweenBullets2));
            StartCoroutine(DelayedShoot(fourthBulletDirection, 2 * delayBetweenBullets1 + delayBetewwnCount + 2 * delayBetweenBullets2));
            StartCoroutine(DelayedShoot(fivethBulletDirection, 2 * delayBetweenBullets1 + delayBetewwnCount + 3 * delayBetweenBullets2));
            StartCoroutine(DelayedShoot(sixthBulletDirection, 2 * delayBetweenBullets1 + delayBetewwnCount + 4 * delayBetweenBullets2));
            //二三轮间隔
            GameObject specialbullet = ObjectPool.Instance.GetObject(specialbulletPrefab);//追踪子弹,追不了一点
            specialbullet.transform.position = shootPoint1.position;
            specialbullet.GetComponent<Bullet>().SetSpeed(shootDirection);
            shootCount = 1;
        }
    }
#endregion

#region 尝试突刺攻击

private void Hit()
{
    Vector2 position = target.position;
    
}


#endregion


    #region 怪物的受伤死亡逻辑
    public void OnTakeDamage(Transform attackTrans)
    {   
        //受击
        attacker = attackTrans;
        isHurt = true;
        _animator.SetTrigger("hurt");//播放受击动画
        StartCoroutine(OnHurt());//使用携程进行一个动作切换的时间间隔
    }

    private IEnumerator OnHurt()
    {
        yield return new WaitForSeconds(0.3f);
        isHurt = false;
    }
    
    public void OnDie()
    {
        gameObject.layer = 5;//这里的第五个图层之后设置为忽略的图层，这里面的物体不会与角色产生碰撞
        _animator.SetBool("Dead",true);
        isDead = true;
    }
    
    public void DestroyObject()
    {
        if (playerBar != null) // 检查是否为空
        {
            playerBar.AddExperienceF(experienceValue); // 触发事件并传递经验值
        }
        Destroy(this.gameObject);//播放死亡动画后摧毁物体
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarEnemy2 : MonoBehaviour
{
    [Header("战斗")]
    public float damage = 1f;
    public float hitRate = 2.5f;//攻击间隔
    private float _lastHit;
    public GameObject bulletPrefab; //子弹（眼泪
    public Transform shootPoint; 
    public Transform target;
    private Animator _animator;
    private SphereCollider attackRangeCollider;

    protected void Start()
    {
        _animator = GetComponent<Animator>();
        shootPoint = transform.Find("ShootPoint");
        ObjectPool objectPool = ObjectPool.Instance;//查看对象池
        attackRangeCollider = GetComponent<SphereCollider>(); // 获取SphereCollider组件
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

        if (distanceToTarget <= attackRangeCollider.radius)
        {
            if (Time.time > _lastHit + 1 / hitRate)
            {
                Shoot();
                _lastHit = Time.time;
            }
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
        // 设置子弹速度
        bullet1.GetComponent<Bullet>().SetSpeed(shootDirection);
        
        // 创建第二颗子弹，添加角度偏移
        float bulletSpreadAngle = 1.0f; // 角度偏移，你可以根据需要调整
        Quaternion bulletRotation = Quaternion.Euler(0, 0, bulletSpreadAngle);

        // 计算第二颗子弹的速度方向，朝向目标的方向加上角度偏移
        Vector3 secondBulletDirection = bulletRotation * shootDirection;

        // 创建第二颗子弹并设置位置为ShootPoint的位置
        GameObject bullet2 = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet2.transform.position = shootPoint.position;

        // 设置子弹速度
        bullet2.GetComponent<Bullet>().SetSpeed(secondBulletDirection);
    }
}

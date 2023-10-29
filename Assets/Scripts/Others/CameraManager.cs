using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 1f;
    private Vector3 targetPos;
    //private static CameraManager instance;

    private void Awake()
    {
        // if (instance == null)
        // {
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);//切换关卡血量经验不变
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }

    private void LateUpdate()
    {   
        targetPos = target.position + new Vector3(5f, 3f, 0);
        if (target != null) {
            if(transform.position != targetPos) 
            {
                Vector3 targetPosition = new Vector3(targetPos.x, targetPos.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            }
        }
    }
}

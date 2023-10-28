using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 1f;
    private Vector3 targetPos;

    private void LateUpdate()
    {   
        targetPos = target.position + new Vector3(5f, 3f, 0);
        if (target != null) {
            if(transform.position != targetPos) {
                Vector3 targetPosition = new Vector3(targetPos.x, targetPos.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            }
        }
    }
}

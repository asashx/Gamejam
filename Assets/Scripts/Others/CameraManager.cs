using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 1f;

    private void LateUpdate() {
        if (target != null) {
            if(transform.position != target.position) 
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
            }
        }
    }
}

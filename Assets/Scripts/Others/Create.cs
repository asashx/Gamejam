using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject essencePrefab;
    public float time = 10f;
    private void Start()
    {
        
        StartCoroutine(CreateBall());
    }

    IEnumerator CreateBall()
    {
        while (true)
        {
            if (essencePrefab != null)
            {
                Instantiate(essencePrefab, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(time);
        }
    }
}

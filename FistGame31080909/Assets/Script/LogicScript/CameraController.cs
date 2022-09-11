using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    bool isFound = false;
    private Transform target;
    [SerializeField]private Vector3 offset;
    [Range(0,10)]
    public float smoothFactor;
    private void FixedUpdate()
    {
        if(!isFound)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            isFound = true;
            transform.position = target.position;

        }
        Follow();
    }

    private void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPostion = Vector3.Lerp(transform.position,targetPosition,smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPostion;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetobj;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;
    void Start()
    {
        cameraOffset = transform.position - targetobj.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = targetobj.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position,newPosition,smoothFactor);

        if (lookAtTarget)
        {
            transform.LookAt(targetobj);
        }
    }
}

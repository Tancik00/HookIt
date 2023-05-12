using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPos;
    public bool isCameraRotate;
    
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos.position, 1.5f * Time.deltaTime);
        if (isCameraRotate)
            transform.forward = Vector3.Lerp(transform.forward, playerPos.forward, 1.5f * Time.deltaTime);
    }
}

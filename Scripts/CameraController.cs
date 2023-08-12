using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 targetCamPos = target.position;
            targetCamPos.z = transform.position.z; // Mantém a posição z da câmera constante
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
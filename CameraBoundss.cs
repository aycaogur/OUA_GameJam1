using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundss : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform target;
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;

            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            virtualCamera.transform.position = targetPosition;
        }
    }
}

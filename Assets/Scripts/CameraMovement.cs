using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
       
        if (target != null)
        {
            Vector3 currentPos = new Vector3(target.position.x, target.position.y, -10);
            transform.position = currentPos;
        }
    }
}

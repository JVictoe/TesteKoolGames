using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target = default;

    private void Update()
    {
        transform.LookAt(target);
    }
}

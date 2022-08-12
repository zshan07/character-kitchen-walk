using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSens;
    private Transform parent;
    void Start()
    {
        parent = transform.parent;
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSens*Time.deltaTime;
        parent.Rotate(Vector3.up,mouseX);

    }
}

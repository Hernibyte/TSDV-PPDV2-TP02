using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMainCamera : MonoBehaviour
{
    [SerializeField] private GameObject nave;
    private Vector3 offSet;
    private float smoothFactor = 0.5f;
    [SerializeField] private bool lookAtPlayer = false;
    [SerializeField] private bool rotateAroundPlayer = true;
    [SerializeField] private float rotationSpeed = 5.0f;
    
    void Start()
    {
        offSet = transform.position - nave.transform.position;
    }

    
    void Update()
    {
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            Quaternion camDownAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, Vector2.left);

            offSet = camTurnAngle * camDownAngle * offSet;
        }

        Vector3 newPos = nave.transform.position + offSet;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer || rotateAroundPlayer)
            transform.LookAt(nave.transform);
    }
}
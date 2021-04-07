using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    Rigidbody m_RigidBody;
    private float yRot = 0.0f;
    private float zRot = 0.0f;


    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        yRot -= Input.GetAxis("Horizontal") * rotationSpeed;
        zRot -= Input.GetAxis("Vertical") * rotationSpeed;

        transform.eulerAngles = new Vector3(0.0f, yRot, zRot);
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            m_RigidBody.AddForce(transform.right * -(movementSpeed));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            m_RigidBody.AddForce(transform.right * movementSpeed);
        }
    }
}
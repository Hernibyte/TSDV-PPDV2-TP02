using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private CharacterController controller;
    private float rot = 0.0f;


    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }
    
    void Update()
    {
        Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * movementSpeed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        rot -= Input.GetAxis("Horizontal") * rotationSpeed;
        transform.eulerAngles = new Vector3(0.0f, rot, 0.0f);
    }
}
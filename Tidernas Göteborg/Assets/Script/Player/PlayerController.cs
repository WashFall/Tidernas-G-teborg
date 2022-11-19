using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    InputController inputController;
    InputAction vertical, horizontal;
    Vector3 movement, clampedVelocity;
    float speed = 10;

    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        vertical = inputController.Movement.Vertical;
        horizontal = inputController.Movement.Horizontal;
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        movement = new Vector3(horizontal.ReadValue<float>(), 0, vertical.ReadValue<float>()).normalized;
        rigidBody.velocity += movement;
        if(rigidBody.velocity.magnitude > 10)
            clampedVelocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -10, 10), 0, Mathf.Clamp(rigidBody.velocity.z, -10, 10)).normalized * 10;
        else
            clampedVelocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -10, 10), 0, Mathf.Clamp(rigidBody.velocity.z, -10, 10));
        rigidBody.velocity = clampedVelocity;
    }
}

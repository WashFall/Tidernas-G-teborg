using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float verticalMovement, horizontalMovement;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement).normalized * 0.2f;
        transform.position += movement;       
    }
}

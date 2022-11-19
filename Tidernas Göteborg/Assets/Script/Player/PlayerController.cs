using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    InputController inputController;
    InputAction vertical, horizontal;
    Vector3 movement, clampedVelocity;
    float speed = 10;
    private bool canMove = true;
    float gravity = -10;
    float yValue = 0;

    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        vertical = inputController.Movement.Vertical;
        horizontal = inputController.Movement.Horizontal;
        inputController.Actions.Debug.performed += SlipOnFish;
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            yValue = rigidBody.velocity.y;
            movement = new Vector3(horizontal.ReadValue<float>(), 0, vertical.ReadValue<float>()).normalized;
            rigidBody.velocity += movement;

            if(rigidBody.velocity.magnitude > 10)
                clampedVelocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -10, 10), 0, Mathf.Clamp(rigidBody.velocity.z, -10, 10)).normalized * speed;
            else
                clampedVelocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -10, 10), 0, Mathf.Clamp(rigidBody.velocity.z, -10, 10));

            if(movement.magnitude == 0)
                clampedVelocity *= 0.9f;

            clampedVelocity.y = yValue;
            rigidBody.velocity = clampedVelocity;
            rigidBody.AddForce(0, gravity, 0, ForceMode.Acceleration);
            Vector3 lookDirection = rigidBody.velocity;
            lookDirection.y = 0;
            transform.rotation = rigidBody.velocity == Vector3.zero ? transform.rotation : Quaternion.LookRotation(lookDirection);
        }
    }

    public async void SlipOnFish(InputAction.CallbackContext ctx)
    {
        Vector3 velocity = rigidBody.velocity;
        await DeactivateControls(0.2f, velocity);
    }

    public async Task DeactivateControls(float time, Vector3 velocity)
    {
        canMove = false;
        float endTime = Time.time + time;
        while(Time.time < endTime)
        {
            rigidBody.velocity = velocity * 2f;
            await Task.Yield();
        }
        canMove = true;
    }
}

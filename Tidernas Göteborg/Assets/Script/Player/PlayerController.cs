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
            movement = new Vector3(horizontal.ReadValue<float>(), 0, vertical.ReadValue<float>()).normalized;
            rigidBody.velocity += movement;
            if(rigidBody.velocity.magnitude > 10)
                clampedVelocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -10, 10), 0, Mathf.Clamp(rigidBody.velocity.z, -10, 10)).normalized * speed;
            else
                clampedVelocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -10, 10), 0, Mathf.Clamp(rigidBody.velocity.z, -10, 10));
            rigidBody.velocity = clampedVelocity;

            transform.rotation = rigidBody.velocity == Vector3.zero ? transform.rotation : Quaternion.LookRotation(rigidBody.velocity);
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

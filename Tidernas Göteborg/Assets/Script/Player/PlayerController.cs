using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private InputController inputController;
    private InputAction vertical, horizontal;
    private Vector3 movement, clampedVelocity;
    private float speed = 10;
    private bool canMove = true;
    private float gravity = -10;
    private float yValue = 0;
    private bool grounded;
    private FishCarryingContainer carriedFishes;

    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        vertical = inputController.Movement.Vertical;
        horizontal = inputController.Movement.Horizontal;
        rigidBody = GetComponent<Rigidbody>();
        carriedFishes = GetComponentInChildren<FishCarryingContainer>();
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
            transform.rotation = movement == Vector3.zero ? transform.rotation : Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.fixedDeltaTime * 2.5f);
        }

        if(grounded == true)
        {
            gravity = -10f;
        }
        else if(grounded == false)
        {
            gravity = -100f;
        }
    }

    public async void SlipOnFish(float time)
    {
        Vector3 velocity = rigidBody.velocity;
        await DeactivateControls(time, velocity);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    List<Collider> colliders;
    List<Rigidbody> rigidbodies;
    PlayerController playerController;
    void Start()
    {
        colliders = new List<Collider>();
        rigidbodies = new List<Rigidbody>();

        colliders.AddRange(GetComponentsInChildren<Collider>(true));
        rigidbodies.AddRange(GetComponentsInChildren<Rigidbody>(true));
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoRagdoll()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = true;
        }
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
        }
        playerController.enabled = false;
    }
    public void ResetRagdoll()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = true;
            rigidBody.useGravity = false;
        }
        playerController.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    List<Collider> colliders;
    List<Rigidbody> rigidbodies;
    void Start()
    {
        colliders = new List<Collider>();
        rigidbodies = new List<Rigidbody>();

        colliders.AddRange(GetComponentsInChildren<Collider>(true));
        rigidbodies.AddRange(GetComponentsInChildren<Rigidbody>(true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DoRagdoll()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = true;
        }
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = false;
        }
    }
    void ResetRagdool()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = true;
        }
    }
}

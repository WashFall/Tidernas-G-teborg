using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class ActivateRagdoll : MonoBehaviour
{
    List<Collider> colliders;
    List<Rigidbody> rigidbodies;
    PlayerController playerController;
    Animator animator;
    [SerializeField]
    GameObject ragdollBones;
    [SerializeField]
    GameObject spawnPoint;
    AudioSource source;
    [SerializeField]
    FishCarryingContainer container;
    void Start()
    {
        colliders = new List<Collider>();
        rigidbodies = new List<Rigidbody>();

        colliders.AddRange(ragdollBones.GetComponentsInChildren<Collider>(true));
        rigidbodies.AddRange(ragdollBones.GetComponentsInChildren<Rigidbody>(true));
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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
        animator.enabled = false;
        playerController.enabled = false;
        source.Play();
        container.ShootOutAllFish();
        StartCoroutine(ResetRagdoll());
    }
    IEnumerator ResetRagdoll()
    {
        yield return new WaitForSeconds(3f);
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = true;
            rigidBody.useGravity = false;
        }
        animator.enabled = true;
        playerController.enabled = true;
        transform.position = spawnPoint.transform.position;
    }
}

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
    bool isDead = false;
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
        if (isDead) { return; }
        isDead = true;
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
        source.pitch = Random.Range(0.8f,1.6f);
        source.Play();
        container.ShootOutAllFish();
        StartCoroutine(ResetRagdoll());
    }
    IEnumerator ResetRagdoll()
    {
        yield return new WaitForSeconds(3f);
        isDead = false;
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

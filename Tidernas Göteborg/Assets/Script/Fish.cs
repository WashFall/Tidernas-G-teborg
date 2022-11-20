using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    FishCarryingContainer container;
    bool fishIsSlippery = false;

    [SerializeField]
        PlayerController playerController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetContainerReference(FishCarryingContainer containerScript)
    {
        container = containerScript;
    }
    void IFlewOutOfContainer()
    {
        if (container != null)
        {
            transform.parent = null;
            container.RemoveFish(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Container"))
        {
            IFlewOutOfContainer();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            fishIsSlippery = true;
        }else if (collision.gameObject.CompareTag("Player") && fishIsSlippery)
        {
            playerController = FindObjectOfType<PlayerController>();
            playerController.SlipOnFish(0.2f);
        }
    }

    internal IEnumerator SetKinematic(bool isKinematic)
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = isKinematic;
    }
}

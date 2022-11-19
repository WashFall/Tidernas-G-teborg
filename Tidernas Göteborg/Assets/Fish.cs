using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    FishCarryingContainer container;
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
        container.RemoveFish(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Container"))
        {
            IFlewOutOfContainer();
        }
    }
}

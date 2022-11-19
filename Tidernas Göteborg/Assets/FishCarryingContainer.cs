using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCarryingContainer : MonoBehaviour
{
    List<GameObject> carryingFish = new List<GameObject>();
    public void AddFish(GameObject fish)
    {
        fish.transform.parent = transform;
        carryingFish.Add(fish);
        fish.GetComponent<Fish>().SetContainerReference(GetComponent<FishCarryingContainer>());
    }
    public void RemoveFish(GameObject fish)
    {
        carryingFish.Remove(fish);
    }
}

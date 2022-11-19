using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCarryingContainer : MonoBehaviour
{
    List<GameObject> carryingFish = new List<GameObject>();

    [SerializeField]
    GameObject dropOffArea;
    [SerializeField]
    MoneyCounter moneyCounter;

    [SerializeField]
    float fishDropOffYOffset = 4;
    public void AddFish(GameObject fish)
    {
        if (carryingFish.Count < 5)
        {
            fish.transform.parent = transform;
            fish.transform.position = new Vector3(transform.position.x, transform.position.y + fishDropOffYOffset, transform.position.z);
            carryingFish.Add(fish);
            fish.GetComponent<Fish>().SetContainerReference(GetComponent<FishCarryingContainer>());
        }
    }
    public void RemoveFish(GameObject fish)
    {
        carryingFish.Remove(fish);
    }
    public void DeliverFish()
    {
        foreach (GameObject fish in carryingFish)
        {
            fish.transform.parent = dropOffArea.transform;
            fish.transform.localPosition = new Vector3(dropOffArea.transform.localPosition.x, dropOffArea.transform.localPosition.y + 2, dropOffArea.transform.localPosition.z);
            moneyCounter.DeliverFish();
        }
        carryingFish.Clear();
    }
}

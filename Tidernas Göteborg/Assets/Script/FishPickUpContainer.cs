using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPickUpContainer : MonoBehaviour
{
    [SerializeField]
        List<GameObject> fishes = new List<GameObject>();
    [SerializeField]
    FishCarryingContainer container;
    public GameObject GetFish()
    {
        if(fishes.Count > 0 && container.carryingFish.Count < 5)
        {
            GameObject fish = fishes[fishes.Count - 1];
            fishes.RemoveAt(fishes.Count - 1);
            return fish;
        }
        else
        {
            return null;
        }
    }
    public void AddFish(GameObject fish)
    {
        fishes.Add(fish);
    }
}

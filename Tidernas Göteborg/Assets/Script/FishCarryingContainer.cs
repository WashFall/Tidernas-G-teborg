using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCarryingContainer : MonoBehaviour
{
    public List<GameObject> carryingFish = new List<GameObject>();

    [SerializeField]
    GameObject dropOffArea;
    [SerializeField]
    MoneyCounter moneyCounter;

    [SerializeField]
    AudioSource source;
    [SerializeField]
    float volume = 2;
    [SerializeField]
        AudioClip splatSfx;    
    [SerializeField]
        AudioClip dropSFX;
    [SerializeField]
    float fishDropOffYOffset = 4;
    public void AddFish(GameObject fish)
    {
        if (carryingFish.Count < 5)
        {
            fish.transform.parent = transform;
            fish.transform.position = new Vector3(transform.position.x + Random.Range(0,0.3f), transform.position.y + fishDropOffYOffset, transform.position.z + Random.Range(0, 0.3f));
            carryingFish.Add(fish);
            fish.GetComponent<Fish>().SetContainerReference(GetComponent<FishCarryingContainer>());
            //StartCoroutine(fish.GetComponent<Fish>().SetKinematic(true));
            fish.GetComponent<Rigidbody>().isKinematic = true;
            AudioSource newSource = Instantiate(source);
            newSource.clip = splatSfx;
            newSource.volume = volume;
            newSource.Play();
            Destroy(newSource, 2);
        }
    }
    public void ShootOutAllFish()
    {
        foreach (var fish in carryingFish)
        {
            Rigidbody rb = fish.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = Vector3.up*10;
            AudioSource newSource = Instantiate(source);
            newSource.clip = splatSfx;
            newSource.volume = volume;
            newSource.Play();
            Destroy(newSource, 2);
        }
        carryingFish.Clear();
    }
    public void RemoveFish(GameObject fish)
    {
        carryingFish.Remove(fish);
        fish.GetComponent<Rigidbody>().isKinematic = false;
        AudioSource.PlayClipAtPoint(splatSfx, Vector3.zero);
    }
    public void DeliverFish()
    {
        foreach (GameObject fish in carryingFish)
        {
            fish.transform.parent = dropOffArea.transform;
            fish.transform.localPosition = new Vector3(Random.Range(0,0.2f), 2, Random.Range(0, 0.2f));
            moneyCounter.DeliverFish();
        }
        AudioSource newSource = Instantiate(source);
        newSource.clip = dropSFX;
        newSource.volume = 1;
        newSource.Play();
        Destroy(newSource, 2);
        carryingFish.Clear();
    }
}

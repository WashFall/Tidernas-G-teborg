using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject fishAsset;
    [SerializeField]
    GameObject spawnPoint;

    FishPickUpContainer container;
    void Start()
    {
        container = GetComponent<FishPickUpContainer>();
        StartCoroutine(SpawnFish());
    }

IEnumerator SpawnFish()
    {
        yield return new WaitForSeconds(Random.Range(2,5));
        GameObject spawnedFish = Instantiate(fishAsset);
        spawnedFish.transform.position = spawnPoint.transform.position;
        container.AddFish(spawnedFish);
        StartCoroutine(SpawnFish());
    }
}

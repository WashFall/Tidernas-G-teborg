using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class Seagull : MonoBehaviour
{
    public Transform[] startingPoints;
    public Transform[] endingPoints;

    [SerializeField] float time;

    Vector3 endPoint;

    bool atStartPosition;

    void Start()
    {
        atStartPosition = true;

        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ActivateRagdoll>().DoRagdoll();
        }
    }

    Vector3 SelectNewDestination(Transform[] spots)
    {
        int newRandomDestination = Random.Range(0, spots.Length);

        return spots[newRandomDestination].position;
    }

    private async void Move()
    {
        await DelayTime(Random.Range(5, 15));

        if (atStartPosition)
        {
            endPoint = SelectNewDestination(endingPoints);
            atStartPosition = false;
        }
        else
        {
            endPoint = SelectNewDestination(startingPoints);
            atStartPosition = true;
        }

        transform.DOMove(endPoint, time / Mathf.Abs(transform.position.z - endPoint.z)).SetEase(Ease.InOutSine).OnComplete(() => Move());
    }

    private async Task DelayTime(int timer)
    {
        float endTime = Time.time + timer;

        while(Time.time < endTime)
        {
            await Task.Yield();
        }
    }
}
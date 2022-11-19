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

    Transform endPoint;

    bool atStartPosition;
    bool inWait = false;

    void Start()
    {
        atStartPosition = false;

        Move();
        endPoint = SelectNewDestination(endingPoints);
    }

    private void Update()
    {
        transform.position += (endPoint.position - transform.position) * 0.1f * Time.deltaTime * 10;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ActivateRagdoll>().DoRagdoll();
        }
    }

    Transform SelectNewDestination(Transform[] spots)
    {
        int newRandomDestination = Random.Range(0, spots.Length);

        return spots[newRandomDestination];
    }

    private async void Move()
    {
        if (!inWait)
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
        }
        Move();
        //transform.DOMove(endPoint, time / Mathf.Abs(transform.position.z - endPoint.z)).SetEase(Ease.InOutSine).OnComplete(() => Move());
    }

    private async Task DelayTime(int timer)
    {
        float endTime = Time.time + timer;
        inWait = true;
        while (Time.time < endTime)
        {
            inWait = false;
            await Task.Yield();
        }
    }
}
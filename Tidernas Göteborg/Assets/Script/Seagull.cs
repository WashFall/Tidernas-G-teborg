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
    float rotation = -90;
    Transform endPoint;

    bool atStartPosition;
    bool inWait = false;
    AudioSource source;

    void Start()
    {
        atStartPosition = false;

        source = GetComponent<AudioSource>();
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
        rotation *= -1;
        int newRandomDestination = Random.Range(0, spots.Length);
        transform.DORotate(new Vector3(0, rotation, 0),0.2f);
        source.Play();
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
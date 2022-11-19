using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWaveRotate : MonoBehaviour
{
    float multiplierRotation = -1;

    [SerializeField]
        float rotateDuration;
    [SerializeField]
        float waitTimeBeforeRotateToOtherDirection;
    [SerializeField]
        float rotation = 25;
    [SerializeField]
        int waveTurnsToWait = 10;
    [SerializeField]
        int waveTurns = 0;
    void Start()
    {
        StartCoroutine(StartRotation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TweenRotation()
    {
        rotation *= multiplierRotation;
        transform.DORotate(new Vector3(rotation, 0, 0), rotateDuration).SetEase(Ease.InOutQuart);
    }
    IEnumerator StartRotation()
    {
        TweenRotation();
        yield return new WaitForSeconds(rotateDuration+waitTimeBeforeRotateToOtherDirection);
        waveTurns++;
        if (waveTurns % waveTurnsToWait == 0)
        {
            rotation = Random.Range(10, 30);
            rotateDuration = Random.Range(1.5f, 4);
            waitTimeBeforeRotateToOtherDirection = Random.Range(1f, 2);
        }
        StartCoroutine(StartRotation());
    }
}

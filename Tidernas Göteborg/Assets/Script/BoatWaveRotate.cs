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
        StartCoroutine(StartRotation());
    }
}

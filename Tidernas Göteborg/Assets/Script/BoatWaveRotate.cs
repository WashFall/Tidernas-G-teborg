using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWaveRotate : MonoBehaviour
{
    float multiplierRotation = -1;

    [SerializeField]
        float rotation = 25;
    void Start()
    {
        TweenRotation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TweenRotation()
    {
        rotation *= multiplierRotation;
        transform.DORotate(new Vector3(rotation, 0, 0), 4).SetEase(Ease.InOutQuart).OnComplete(TweenRotation);
    }
}

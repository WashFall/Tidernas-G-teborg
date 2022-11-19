using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TjuckeStomachGrow : MonoBehaviour
{
    public Transform tjuckeHead;

    void GrowStomach()
    {
        Vector3 growthScale = new Vector3(0.1f, 0.1f, 0.1f);
        Vector3 newHeadPos = new Vector3(0, 0.2f, 0);
        Vector3 newBodyPos = new Vector3(0, 0.1f, 0);

        transform.localScale += growthScale;

        tjuckeHead.localPosition += newHeadPos;
        transform.localPosition += newBodyPos;
    }

    private void OnEnable()
    {
        MoneyCounter.tjuckeGrow += GrowStomach;
    }

    private void OnDisable()
    {
        MoneyCounter.tjuckeGrow -= GrowStomach;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TjuckeStomachGrow : MonoBehaviour
{
    public GameObject tjuckeGlenn;
    public Transform tjuckeHead;
    public GameObject[] tjuckeMeshes;

    private Rigidbody rb;

    private float maxSize = 2;
 
    void GrowStomach()
    {
        Vector3 growthScale = new Vector3(0.1f, 0.1f, 0.1f);
        Vector3 newHeadPos = new Vector3(0, 0.2f, 0);
        Vector3 newBodyPos = new Vector3(0, 0.1f, 0);

        transform.localScale += growthScale;

        tjuckeHead.localPosition += newHeadPos;
        transform.localPosition += newBodyPos;

        if(transform.localScale.x > maxSize)
        {
            rb = tjuckeGlenn.GetComponent<Rigidbody>();
            rb.AddForce(0, 20, 1);
        }
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

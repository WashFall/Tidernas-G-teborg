using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text tjuckeGlennText;
    public TMP_Text tunneGlennText;

    [HideInInspector] public float tunneGlenn�re;
    [HideInInspector] public float tjuckeGlenn�re;
    [HideInInspector] public float tunneGlennKronor;
    [HideInInspector] public float tjuckeGlennKronor;

    void Start()
    {
        tunneGlenn�re = 0;
        tjuckeGlenn�re = 0;

        tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlenn�re + "�re";
        tunneGlennText.text = "Tunne Glenn: " + tunneGlenn�re + "�re";
    }

    void Update()
    {
        //TODO: Change below condition to trigger when fish is dropped off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tunneGlenn�re = tunneGlenn�re + 14;
            tjuckeGlenn�re = CalculateTjuckeMoney(tunneGlenn�re);

            if (tjuckeGlenn�re > 100)
            {

            }
            else
            {
                tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlenn�re + "�re";
            }

            if (tunneGlenn�re > 100)
            {

            }
            else
            {
                tunneGlennText.text = "Tunne Glenn: " + tunneGlenn�re + "�re";
            }
        }
    }

    float CalculateTjuckeMoney(float tunneMoney)
    {
        float tjuckeMoney = (Mathf.Round(tunneMoney * 10));
        return tjuckeMoney;
    }

    float CalculateKronor(float �ren)
    {

    }
}

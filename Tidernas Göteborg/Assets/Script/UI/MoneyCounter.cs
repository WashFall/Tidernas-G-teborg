using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text tjuckeGlennText;
    public TMP_Text tunneGlennText;

    [HideInInspector] public float tunneGlennMoney;
    [HideInInspector] public float tjuckeGlennMoney;

    void Start()
    {
        tunneGlennMoney = 0;
        tjuckeGlennMoney = 0;

        tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennMoney;
        tunneGlennText.text = "Tunne Glenn: " + tunneGlennMoney;
    }

    void Update()
    {
        //TODO: Change below condition to trigger when fish is dropped off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tunneGlennMoney = tunneGlennMoney + 1;
            tjuckeGlennMoney = CalculateTjuckeMoney(tunneGlennMoney);

            tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennMoney;
            tunneGlennText.text = "Tunne Glenn: " + tunneGlennMoney;
        }
    }

    float CalculateTjuckeMoney(float tunneMoney)
    {
        float tjuckeMoney = (Mathf.Round(tunneMoney * 10));
        return tjuckeMoney;
    }
}

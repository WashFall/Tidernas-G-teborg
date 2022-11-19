using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text tjuckeGlennText;
    public TMP_Text tunneGlennText;

    [HideInInspector] public float tunneGlennÖre;
    [HideInInspector] public float tjuckeGlennÖre;
    [HideInInspector] public float tunneGlennKronor;
    [HideInInspector] public float tjuckeGlennKronor;

    void Start()
    {
        tunneGlennÖre = 0;
        tjuckeGlennÖre = 0;

        tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennÖre + "öre";
        tunneGlennText.text = "Tunne Glenn: " + tunneGlennÖre + "öre";
    }

    void Update()
    {
        //TODO: Change below condition to trigger when fish is dropped off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tunneGlennÖre = tunneGlennÖre + 14;
            tjuckeGlennÖre = CalculateTjuckeMoney(tunneGlennÖre);

            if (tjuckeGlennÖre > 100)
            {

            }
            else
            {
                tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennÖre + "öre";
            }

            if (tunneGlennÖre > 100)
            {

            }
            else
            {
                tunneGlennText.text = "Tunne Glenn: " + tunneGlennÖre + "öre";
            }
        }
    }

    float CalculateTjuckeMoney(float tunneMoney)
    {
        float tjuckeMoney = (Mathf.Round(tunneMoney * 10));
        return tjuckeMoney;
    }

    float CalculateKronor(float ören)
    {

    }
}

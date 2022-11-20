using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MoneyCounter : MonoBehaviour
{
    public delegate void TjuckeGrow();
    public static event TjuckeGrow tjuckeGrow;

    public TMP_Text tjuckeGlennText;
    public TMP_Text tunneGlennText;

    [HideInInspector] public float tunneGlenn�re;
    [HideInInspector] public float tjuckeGlenn�re;
    [HideInInspector] public float tunneGlennKronor;
    [HideInInspector] public float tjuckeGlennKronor;
    [SerializeField] private float fishValue;

    void Start()
    {
        tunneGlenn�re = 0;
        tjuckeGlenn�re = 0;

        WriteOutMoney();
    }

    void Update()
    {
        //TODO: Change below condition to trigger when fish is dropped off
        
    }

    public void DeliverFish()
    {
        tunneGlenn�re = tunneGlenn�re + fishValue;
        tjuckeGlenn�re += fishValue * 10;

        if (tjuckeGlenn�re >= 100)
        {
            tjuckeGlenn�re = Mathf.Round(tjuckeGlenn�re - 100);
            tjuckeGlennKronor = CalculateKronor(tjuckeGlennKronor);
            
            tjuckeGrow?.Invoke();
        }

        if (tunneGlenn�re >= 100)
        {
            tunneGlenn�re = Mathf.Round(tunneGlenn�re - 100);
            tunneGlennKronor = CalculateKronor(tunneGlennKronor);
        }

        WriteOutMoney();
    }

    float CalculateKronor(float kronor)
    {
        float nyaKronor = kronor + 1;

        return nyaKronor;
    }

    void WriteOutMoney()
    {
        tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennKronor + " kronor och " + tjuckeGlenn�re + " �re";
        tunneGlennText.text = "Tunne Glenn: " + tunneGlennKronor + " kronor och " + tunneGlenn�re + " �re";
    }
}

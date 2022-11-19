using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text tjuckeGlennText;
    public TMP_Text tunneGlennText;

    [HideInInspector] public float tunneGlennÖre;
    [HideInInspector] public float tjuckeGlennÖre;
    [HideInInspector] public float tunneGlennKronor;
    [HideInInspector] public float tjuckeGlennKronor;

    private float fishValue;
    private InputController inputController;

    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        inputController.Actions.Debug.performed += DeliverFish;

        fishValue = 14;
        tunneGlennÖre = 0;
        tjuckeGlennÖre = 0;

        WriteOutMoney();
    }

    void Update()
    {
        //TODO: Change below condition to trigger when fish is dropped off
        
    }

    private void DeliverFish(InputAction.CallbackContext ctx)
    {
        tunneGlennÖre = tunneGlennÖre + fishValue;
        tjuckeGlennÖre = CalculateTjuckeMoney(tunneGlennÖre);

        if (tjuckeGlennÖre > 100)
        {
            tjuckeGlennÖre = tjuckeGlennÖre - 100;
            CalculateKronor(tjuckeGlennKronor);
        }

        if (tunneGlennÖre > 100)
        {
            tunneGlennÖre = tunneGlennÖre - 100;
            CalculateKronor(tunneGlennKronor);
        }

        WriteOutMoney();
    }

    float CalculateTjuckeMoney(float tunneMoney)
    {
        float tjuckeMoney = (Mathf.Round(tunneMoney * 10));
        return tjuckeMoney;
    }

    float CalculateKronor(float kronor)
    {
        float nyaKronor = kronor + 1;

        return nyaKronor;
    }

    void WriteOutMoney()
    {
        tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennKronor + "kronor och " + tjuckeGlennÖre + "öre";
        tunneGlennText.text = "Tunne Glenn: " + tunneGlennKronor + "kronor och " + tunneGlennÖre + "öre";
    }
}

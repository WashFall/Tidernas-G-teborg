using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text tjuckeGlennText;
    public TMP_Text tunneGlennText;

    [HideInInspector] public float tunneGlenn�re;
    [HideInInspector] public float tjuckeGlenn�re;
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
        tunneGlenn�re = 0;
        tjuckeGlenn�re = 0;

        WriteOutMoney();
    }

    void Update()
    {
        //TODO: Change below condition to trigger when fish is dropped off
        
    }

    private void DeliverFish(InputAction.CallbackContext ctx)
    {
        tunneGlenn�re = tunneGlenn�re + fishValue;
        tjuckeGlenn�re = CalculateTjuckeMoney(tunneGlenn�re);

        if (tjuckeGlenn�re > 100)
        {
            tjuckeGlenn�re = tjuckeGlenn�re - 100;
            CalculateKronor(tjuckeGlennKronor);
        }

        if (tunneGlenn�re > 100)
        {
            tunneGlenn�re = tunneGlenn�re - 100;
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
        tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennKronor + "kronor och " + tjuckeGlenn�re + "�re";
        tunneGlennText.text = "Tunne Glenn: " + tunneGlennKronor + "kronor och " + tunneGlenn�re + "�re";
    }
}

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

    [HideInInspector] public float tunneGlennÖre;
    [HideInInspector] public float tjuckeGlennÖre;
    [HideInInspector] public float tunneGlennKronor;
    [HideInInspector] public float tjuckeGlennKronor;

    [SerializeField] private float fishValue;
    private InputController inputController;

    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        inputController.Actions.Debug.performed += DeliverFish;

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
        tjuckeGlennÖre += fishValue * 10;

        if (tjuckeGlennÖre >= 100)
        {
            tjuckeGlennÖre = Mathf.Round(tjuckeGlennÖre - 100);
            tjuckeGlennKronor = CalculateKronor(tjuckeGlennKronor);
            
            tjuckeGrow?.Invoke();
        }

        if (tunneGlennÖre >= 100)
        {
            tunneGlennÖre = Mathf.Round(tunneGlennÖre - 100);
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
        tjuckeGlennText.text = "Tjucke Glenn: " + tjuckeGlennKronor + " kronor och " + tjuckeGlennÖre + " öre";
        tunneGlennText.text = "Tunne Glenn: " + tunneGlennKronor + " kronor och " + tunneGlennÖre + " öre";
    }
}

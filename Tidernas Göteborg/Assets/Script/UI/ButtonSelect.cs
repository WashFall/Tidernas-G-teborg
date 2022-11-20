using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour
{
    public GameObject button;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}

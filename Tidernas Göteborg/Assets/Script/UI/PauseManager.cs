using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;
    private InputController inputController;

    void Start()
    {
        inputController = new InputController();
        inputController.Enable();
        inputController.Actions.Pause.performed += PauseGame;
    }

    private void PauseGame(InputAction.CallbackContext ctx)
    {
        if(Time.timeScale > 0) Time.timeScale = 0;
        else Time.timeScale = 1;

        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }
}

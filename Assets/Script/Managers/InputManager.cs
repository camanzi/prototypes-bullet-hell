using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputSystem InputSystem
    {
        get
        {
            _inputSystem ??= new InputSystem();
            return _inputSystem;
        }
    }
    private static InputSystem _inputSystem;

    private void Awake()
    {
        //InputSystem.GamePlay.Pause.performed += PauseGame;

        //InputSystem.Pause.Resume.performed += ResumeGame;
    }

    private void ResumeGame(InputAction.CallbackContext context)
    {
        //GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        //GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Pause;
    }



    #region GAMEPLAY INPUTS
    public static bool invertedX, invertedY, invertRotaion;
    public static Vector2 MovementInput()
    {
        return InputSystem.GamePlay.Movement.ReadValue<Vector2>().normalized;
    }
    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SOInputReader : ScriptableObject, Controls.IPlayerActions
{
    public event Action<bool> OnPlayerPrimaryFire;
    public event Action<Vector2> OnPlayerMove;

    Controls controls;
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        OnPlayerMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            OnPlayerPrimaryFire?.Invoke(true);
        }
        else if (context.canceled == true)
        {
            OnPlayerPrimaryFire?.Invoke(false);
        }
    }
}

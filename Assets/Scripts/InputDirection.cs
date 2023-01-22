using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDirection : MonoBehaviour
{
    [SerializeField] Hero _hero;

    public void Movement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.Interact();
            
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.Attack();
            
        }
    }

    public void GoThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.UseInventory();
        }
    }

    public void Dodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.Dodge();
        }
    }
    public void OnNextItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.NextItem();
        }
    }

    public void OnUsePerk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hero.UsePerk();
        }
    }
    public void OnToggleFlashlight(InputAction.CallbackContext context)
    {
        if (context.performed)
            _hero.ToggleFlashlight();
    }


}
   
    


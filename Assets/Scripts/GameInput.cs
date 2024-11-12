using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }


    public Vector2 GetMovementVectorNormalized()
    {
        return playerInputActions.Player.Movement.ReadValue<Vector2>().normalized;
    }


    public bool IsRunning()
    {
        return playerInputActions.Player.Running.IsInProgress() && playerInputActions.Player.Movement.IsInProgress();
    }


    private void OnDestroy()
    {
        playerInputActions.Player.Disable();
    }
}

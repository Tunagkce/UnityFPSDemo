
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private InputSystem_Actions playerInput;
    private InputSystem_Actions.PlayerActions playerMovements;
    private PlayerMotor playerMotor;
    private PlayerLook look;
    void Awake()
    {
        playerInput = new InputSystem_Actions();
        playerMovements = playerInput.Player;
        playerMotor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        playerMovements.Jump.performed += ctx => playerMotor.Jump();
        playerMovements.Sprint.performed += ctx => playerMotor.StartSprinting();
        playerMovements.Sprint.canceled += ctx => playerMotor.StopSprinting();
    }
    void FixedUpdate()
    {
        // tell the player motor to move using the value from the movement action.
        playerMotor.ProcessMove(playerMovements.Move.ReadValue<Vector2>());
        
    }
    void LateUpdate()
    {
        look.ProcessLook(playerMovements.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

}

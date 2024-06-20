using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public FrameInput FrameInput {  get; private set; }
    private PlayerInputActions _playerInputActions;
    private InputAction _move;
    private InputAction _grab;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();

        _move = _playerInputActions.Player.Move;
        _grab = _playerInputActions.Player.Grab;
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    private void Update()
    {
        FrameInput = GatherInput();
    }

    private FrameInput GatherInput()
    {
        return new FrameInput
        {
            Move = _move.ReadValue<Vector2>(),
            Grab = _grab.WasPressedThisFrame()
        };
    }
}

public struct FrameInput
{
    public Vector2 Move;
    public bool Grab;
}

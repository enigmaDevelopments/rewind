using UnityEngine;
using UnityEngine.InputSystem;

public class InputType : MonoBehaviour
{
    public enum InputMethiod : byte
    {
        Keyboard,
        Gamepad
    }
    public PlayerInput input;
    public static InputMethiod inputMethod;
    void Start()
    {
        input.onControlsChanged += OnControlsChanged;

    }

    private void OnControlsChanged(PlayerInput input)
    {
        if (input.currentControlScheme == "Keyboard&Mouse")
            inputMethod = InputMethiod.Keyboard;
        else if (input.currentControlScheme == "Gamepad")
            inputMethod = InputMethiod.Gamepad;
    }
}

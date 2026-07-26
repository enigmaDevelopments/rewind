using UnityEngine;

public class MultiButton : ButtonState
{
    public ButtonState[] buttonStates;
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        foreach (var button in buttonStates)
            button.TurnOn();
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        foreach (var button in buttonStates)
            button.TurnOff();
    }
}
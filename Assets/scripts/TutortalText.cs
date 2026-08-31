using TMPro;
using UnityEngine;

public class TutortalText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public string start;
    public string keyboard;
    public string gamepad;
    public string end;
    void Update()
    {
        textMeshPro.text = start + (InputType.inputMethod == 0 ? keyboard : gamepad) + end;
    }
}

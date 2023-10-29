using UnityEngine;

public class PCInput : IInputHandler
{
    private const string _horAxisName = "Horizontal";
    private const string _verAxisName = "Vertical";

    private const string _interactName = "Interact";

    public Vector3 GetDirection() => 
        new(Input.GetAxis(_horAxisName), 0, Input.GetAxis(_verAxisName));

    public bool Interact() => 
        Input.GetAxis(_interactName) > 0;
}
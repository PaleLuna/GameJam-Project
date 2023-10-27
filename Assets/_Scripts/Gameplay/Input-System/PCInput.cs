using UnityEngine;

public class PCInput : IInputHandler
{
    private const string _horAxisName = "Horizontal";
    private const string _verAxisName = "Vertical";

    public Vector3 GetDirection()
    {
        return new Vector3(Input.GetAxis(_horAxisName), 0, Input.GetAxis(_verAxisName));
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
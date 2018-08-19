using SAGAMES.GameFramework.InputSystem.Interfaces;
using UnityEngine;

public class RadialMouseInputHandler : IMouseInputHandler
{
    #region Contract Methods

    public Vector2 GetInput()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width / 2, mousePos.y - Screen.height / 2);
        float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
        return rot.eulerAngles;
    }

    public Vector2 GetRawPosition()
    {
        return Input.mousePosition;
    }

    #endregion
}
//By Sean González

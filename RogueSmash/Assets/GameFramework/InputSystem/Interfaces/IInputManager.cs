using UnityEngine;
using System;

namespace SAGAMES.GameFramework.InputSystem.Interfaces
{
    public interface IInputManager
    {
        #region Contract Methods

        void AddActionToBinding(string binding, Action action);
        float GetAxis(string axisName);
        bool GetButton(string buttonName);
        Vector2 GetMouseVector();

        #endregion
    }
}
//By Sean González

using UnityEngine;
namespace SAGAMES.GameFramework.InputSystem.Interfaces
{
    public interface IMouseInputHandler
    {
        #region Contract Methods

        Vector2 GetRawPosition();
        Vector2 GetInput();

        #endregion
    }
}
//By Sean González

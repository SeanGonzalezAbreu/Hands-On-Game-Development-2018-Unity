using SAGAMES.GameFramework.ResourceSystem.Interfaces;

namespace SAGAMES.GameFramework.InputSystem.Interfaces
{
    public interface IWeapon
    {
        #region Contract Methods
        IResource Ammo { get; }
        bool Shoot();
        void Reload();

        #endregion
    }
}
//By Sean González

using UnityEngine;

namespace SAGAMES.GameFramework.Physics.Interfaces
{
    public interface ICollisionExitHandler
    {
        #region Contract Methods

        void Handle(GameObject _instigator, Collision _collision);

        #endregion
    }
}
//By Sean González

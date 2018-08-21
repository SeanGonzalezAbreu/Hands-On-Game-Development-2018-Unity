using UnityEngine;

namespace SAGAMES.GameFramework.Physics.Interfaces
{
    public interface ICollisionEnterHandler
    {
        #region Contract Methods

        void Handle(GameObject _instigator, Collision _collision);

        #endregion
    }
}
//By Sean González

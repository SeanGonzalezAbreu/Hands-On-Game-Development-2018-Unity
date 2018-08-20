using System;

namespace SAGAMES.GameFramework.EnemiesAI.Interfaces
{
    public interface IEnemyAbility
    {
        #region Contract Methods

        event Action onBegin;
        event Action onComplete;
        void UseAbility();

        #endregion
    }
}
//By Sean González

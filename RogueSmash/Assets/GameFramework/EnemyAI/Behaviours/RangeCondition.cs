using SAGAMES.GameFramework.EnemiesAI.Interfaces;
using UnityEngine;

namespace SAGAMES.GameFramework.EnemiesAI
{
    public class RangeCondition : IActionCondition
    {
        #region Variables

        private Transform positionA;
        private Transform positionB;
        private float minRange;

        #endregion
        #region Constructors

        public RangeCondition(Transform _a, Transform _b, float _minRange)
        {
            positionA = _a;
            positionB = _b;
            this.minRange = _minRange;
        }

        #endregion
        #region Contract Methods

        public bool CheckCondition()
        {
            float distance = Vector3.Distance(positionA.position, positionB.position);
            if (distance < minRange)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
//By Sean González

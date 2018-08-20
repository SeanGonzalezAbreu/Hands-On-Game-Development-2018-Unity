using SAGAMES.GameFramework.EnemiesAI.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace SAGAMES.GameFramework.EnemiesAI
{
    public class RoamBehaviour : IMovementBehaviour
    {
        #region Variables

        protected NavMeshAgent agent;
        protected Vector3 targetPosition;
        protected float roamingRange;

        #endregion

        #region Constructor

        public RoamBehaviour(NavMeshAgent _agent, float _roamingRange)
        {
            this.agent = _agent;
            this.roamingRange = _roamingRange;
        }

        #endregion

        #region Contract Methods

        public void SetNextTargetPosition()
        {
            targetPosition = agent.transform.position + new Vector3(Random.Range(-roamingRange, roamingRange), 0,
                Random.Range(-roamingRange, roamingRange));
            agent.SetDestination(targetPosition);
        }

        #endregion
    }
}
//By Sean González

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SAGAMES.GameFramework.EnemiesAI.Interfaces;
using System;

namespace SAGAMES.GameFramework.EnemiesAI
{
    public class BasicEnemy : MonoBehaviour
    {
        #region Variables

        protected IMovementBehaviour movementBehavior;
        protected Dictionary<IActionCondition, IEnemyAbility> abilities =
            new Dictionary<IActionCondition, IEnemyAbility>();
        protected NavMeshAgent agent;
        protected GameObject player;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player");
            movementBehavior = new RoamBehaviour(agent, 5);
            AddDashAbility();
        }


        private void Update()
        {
            if (!agent.hasPath)
            {
                movementBehavior.SetNextTargetPosition();

            }
            CheckConditions();
        }

        #endregion

        #region Class Methods

        private void AddDashAbility()
        {
            DashAbility ability = new DashAbility(gameObject, player.transform);
            ability.onBegin += () => { agent.isStopped = true; };
            ability.onComplete += () => { agent.isStopped = false; };
            abilities.Add(new RangeCondition(transform, player.transform, 7.0f), ability);
        }

        private void CheckConditions()
        {
            foreach (var kvp in abilities)
            {
                if (kvp.Key.CheckCondition())
                {
                    kvp.Value.UseAbility();
                }
            }
        }
        #endregion
    }
}
//By Sean González

using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using SAGAMES.GameFramework.EnemiesAI;
using SAGAMES.GameFramework.EnemiesAI.Interfaces;
using SAGAMES.GameFramework.EnemiesAI.Abilities;
using System;

namespace SAGAMES.RogueSmash.Enemies
{
    public class BasicBoss : MonoBehaviour
    {
        #region Variables

        protected IMovementBehaviour movementBehaviour;
        protected Dictionary<IActionCondition, IEnemyAbility> abilities =
            new Dictionary<IActionCondition, IEnemyAbility>();
        protected NavMeshAgent agent;
        protected GameObject player;
        [SerializeField] protected GameObject projectilePrefab;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player");
            //Initializing interfaces
            movementBehaviour = new RoamBehaviour(agent, 8);
            SetupAbilities();
        }

        private void Update()
        {
            if (!agent.hasPath)
            {
                movementBehaviour.SetNextTargetPosition();
            }
            CheckConditions();
        }

        #endregion

        #region Class Methods

        private void SetupAbilities()
        {
            BurstAttack ba = new BurstAttack(4, transform, projectilePrefab);
            ba.onBegin += () => { agent.isStopped = false; };
            ba.onComplete += () => { agent.isStopped = true; };
            RangeCondition rc = new RangeCondition(transform, player.transform, 12);
            abilities.Add(rc, ba);
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

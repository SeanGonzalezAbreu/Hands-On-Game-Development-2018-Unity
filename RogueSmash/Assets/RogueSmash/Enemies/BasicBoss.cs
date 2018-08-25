using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using SAGAMES.GameFramework.EnemiesAI;
using SAGAMES.GameFramework.ResourceSystem;
using SAGAMES.GameFramework.EnemiesAI.Interfaces;
using SAGAMES.GameFramework.EnemiesAI.Abilities;
using SAGAMES.GameFramework.ResourceSystem.Interfaces;
using SAGAMES.GameFramework.Physics.Interfaces;

namespace SAGAMES.RogueSmash.Enemies
{
    public class BasicBoss : MonoBehaviour, IDamageable
    {
        #region Variables

        protected IResource health;
        public IResource Health { get { return health; } }
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
            health = new Health(10);
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

        private void OnCollisionEnter(Collision _collision)
        {
            ICollisionEnterHandler[] handlers =
            _collision.gameObject.GetComponents<ICollisionEnterHandler>();
            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(this.gameObject, _collision);
                }
            }
        }
        #endregion

        #region Class Methods

        private void SetupAbilities()
        {
            BurstAttack ba = new BurstAttack(4, transform, projectilePrefab);
            ba.onBegin += () => { agent.isStopped = false; };
            ba.onComplete += () => { agent.isStopped = true; };
            RangeCondition rc = new RangeCondition(transform, player.transform, 20);//Rango de Ataque
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
        #region Contract Methods

        public void Damage(float _amount)
        {
            health.Remove(_amount);
        }

        #endregion
    }
}
//By Sean González

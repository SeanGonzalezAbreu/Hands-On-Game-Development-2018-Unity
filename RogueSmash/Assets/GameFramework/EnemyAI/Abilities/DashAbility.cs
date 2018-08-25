using System;
using System.Collections;
using SAGAMES.GameFramework.Coroutines;
using SAGAMES.GameFramework.EnemiesAI.Interfaces;
using UnityEngine;

namespace SAGAMES.GameFramework.EnemiesAI.Abilities
{
    public class DashAbility : IEnemyAbility
    {
        #region Variables

        private bool inUse;
        private bool isLockedOn;
        //private float lockOnDistance = 7.0f;
        private float lockOnTime = 2.0f;

        private float dashSpeed = 30.0f;
        private float dashDuration = 0.4f;

        protected GameObject actor;
        protected Transform target;


        #endregion

        #region Constructors

        public DashAbility(GameObject _actor, Transform _target)
        {
            this.actor = _actor;
            this.target = _target;
        }

        #endregion

        #region Contract Methods

        public event Action onBegin;
        public event Action onComplete;

        public void UseAbility()
        {
            if (inUse) return;
            inUse = true;
            if (onBegin != null)
            {
                onBegin.Invoke();
            }
            CoroutineHelper.RunCoroutine(ChargeAttack);
        }
        #endregion
        #region Class Methods

        private IEnumerator ChargeAttack()
        {
            float chargeMeter = 0f;
            while (chargeMeter < lockOnTime)
            {
                actor.transform.LookAt(target);
                chargeMeter += Time.deltaTime;
                yield return null;
            }
            CoroutineHelper.RunCoroutine(Dash);
        }

        private IEnumerator Dash()
        {
            float dashTimer = 0.0f;
            while (dashTimer < dashDuration)
            {
                actor.transform.position += actor.transform.forward * dashSpeed * Time.deltaTime;
                dashTimer += Time.deltaTime;
                yield return null;
            }
            if (onComplete != null)
            {
                onComplete.Invoke();
            }
            inUse = false;
        }

        #endregion
    }
}
//By Sean González

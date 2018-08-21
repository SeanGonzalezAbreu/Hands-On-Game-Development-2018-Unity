using System.Collections;
using SAGAMES.GameFramework.Coroutines;
using SAGAMES.GameFramework.EnemiesAI.Interfaces;
using System;
using UnityEngine;
using SAGAMES.RogueSmash.Weapons;

namespace SAGAMES.GameFramework.EnemiesAI.Abilities
{
    public class BurstAttack : IEnemyAbility
    {
        #region Variables

        private readonly float burstIterations;
        private Transform emissionPoint;
        private GameObject bulletPrefab;
        private float duration;
        private float steps;
        private float proyectileSpeed;
        private float groundHeight;
        private bool inUse;
        private float lifeTime;

        #endregion

        #region Constructors

        public BurstAttack(int _burstCount, Transform _emissionPoint, GameObject _bulletPrefab,
            float _proyectileSpeed = 70.0f, float _groundHeight = .5f, float _duration = 2.0f,
            int _steps = 36, float _lifeTime = 4.0f)
        {
            burstIterations = Mathf.PI * 2 * _burstCount;
            this.emissionPoint = _emissionPoint;
            this.bulletPrefab = _bulletPrefab;
            this.duration = _duration;
            this.steps = _steps * _burstCount;
            this.proyectileSpeed = _proyectileSpeed;
            this.groundHeight = _groundHeight;
            this.lifeTime = _lifeTime;
        }

        #endregion

        #region Contract Methods

        public event Action onBegin;
        public event Action onComplete;

        public void UseAbility()
        {
            if (inUse) return;
            if (onBegin != null)
            {
                onBegin.Invoke();
            }
            inUse = true;
            CoroutineHelper.RunCoroutine(Burst);
        }

        #endregion

        #region Class Methods

        private IEnumerator Burst()
        {
            float timer = burstIterations;
            float mult = timer / duration;
            float t = 0.0f;
            while (t < duration)
            {
                t += (duration / steps);
                Vector3 point = new Vector3(emissionPoint.position.x + Mathf.Sin(t * mult) * 2, groundHeight,
                    emissionPoint.position.z + Mathf.Cos(t * mult) * 2);
                Vector3 dir = point - emissionPoint.position;
                dir.Normalize();
                dir = emissionPoint.position + dir * 10;
                dir.y = 0.2f;
                GameObject ins = UnityEngine.Object.Instantiate(bulletPrefab, point, Quaternion.identity);
                ins.transform.LookAt(dir);
                ins.GetComponent<Rigidbody>().velocity = ins.transform.forward * proyectileSpeed;
                GameObject.Destroy(ins, lifeTime);
                yield return new WaitForSeconds(duration / steps);

            }
            inUse = false;
            if (onComplete != null)
            {
                onComplete.Invoke();
            }
        }

        #endregion
    }
}
//By Sean González

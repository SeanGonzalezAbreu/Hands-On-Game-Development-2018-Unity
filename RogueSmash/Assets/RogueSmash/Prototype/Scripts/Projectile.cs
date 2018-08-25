using SAGAMES.GameFramework.Physics.Interfaces;
using SAGAMES.GameFramework.ResourceSystem.Interfaces;
using System.Collections;
using UnityEngine;
namespace SAGAMES.RogueSmash.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour, ICollisionEnterHandler
    {
        #region Variables

        private float lifetime;
        private Vector3 direction;
        private float projectileVelocity;
        private bool isAlive;
        private Rigidbody rb;
        #endregion

        #region Unity Methods

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {

            //if (isAlive) transform.position += direction * Time.deltaTime * projectilVelocity;
            if (isAlive) rb.velocity = direction * projectileVelocity;
        }

        #endregion

        #region Class Methods

        public void Init(Vector3 _direction, float _velocity = 20.0f, float _lifetime = 1.0f)
        {
            this.direction = _direction;
            this.projectileVelocity = _velocity;
            this.lifetime = _lifetime;
        }

        public void Shoot()
        {
            StartCoroutine(DeathTimer(lifetime));
            isAlive = true;
        }
        public IEnumerator DeathTimer(float _timer)
        {
            yield return new WaitForSeconds(_timer);
            Destroy(gameObject);
        }

        #endregion

        #region Contract Methods

        //private void OnCollisionEnter(Collision collision)
        //{
        //    IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        //    if (damageable != null)
        //    {
        //        damageable.Damage(1);
        //        Debug.Log("BOSS HIT");
        //    }
        //}
        public void Handle(GameObject _instigator, Collision _collision)
        {
            IDamageable damageable = _instigator.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(1);
                Debug.Log("BOSS HIT");
            }
        }

        #endregion
    }
}
//By Sean González

using System.Collections;
using UnityEngine;
namespace SAGAMES.RogueSmash.Weapons
{
    public class Projectile : MonoBehaviour
    {
        #region Variables

        private float lifetime;
        private Vector3 direction;
        private float projectilVelocity;
        private bool isAlive;
        #endregion

        #region Unity Methods

        void Update()
        {

            if (isAlive) transform.position += direction * Time.deltaTime * projectilVelocity;
            //if (isAlive) rb.velocity = direction * projectilVelocity;
        }

        #endregion

        #region Class Methods

        public void Init(Vector3 _direction, float _velocity = 20.0f, float _lifetime = 1.0f)
        {
            this.direction = _direction;
            this.projectilVelocity = _velocity;
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
    }
}
//By Sean González

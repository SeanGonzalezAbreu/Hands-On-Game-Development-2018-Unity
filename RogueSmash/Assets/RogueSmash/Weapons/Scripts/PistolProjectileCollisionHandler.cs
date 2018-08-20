using SAGAMES.GameFramework.Physics.Interfaces;
using UnityEngine;

namespace SAGAMES.RogueSmash.Weapons
{
    public class PistolProjectileCollisionHandler : MonoBehaviour
    {
        #region Unity Methods

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
            Destroy(gameObject);
        }

        #endregion
    }
}
//By Sean González

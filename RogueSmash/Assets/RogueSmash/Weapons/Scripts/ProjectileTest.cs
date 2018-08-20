using SAGAMES.GameFramework.Physics.Interfaces;
using UnityEngine;

namespace SAGAMES.RogueSmash.Weapons
{
    public class ProjectileTest : MonoBehaviour, ICollisionEnterHandler
    {
        #region Contract Methods

        public void Handle(GameObject _instigator, Collision _collision)
        {
            Debug.Log("Ouch is was hit by " + _instigator.name);
        }
        #endregion
    }
}
//By Sean González

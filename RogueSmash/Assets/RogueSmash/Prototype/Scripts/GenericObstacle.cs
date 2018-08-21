using SAGAMES.GameFramework.Physics.Interfaces;
using UnityEngine;

namespace SAGAMES.RogueSmash.Prototype.Scripts
{
    public class GenericObstacle : MonoBehaviour, ICollisionEnterHandler
    {
        #region Contract Methods

        public void Handle(GameObject _instigator, Collision _collision)
        {
            //TODO Implement damage code here
            //TODO Implement Knockback code here
            Debug.Log(string.Format("Game Object Entered: {0} ", _instigator.name));
        }

        #endregion
    }
}
//By Sean González

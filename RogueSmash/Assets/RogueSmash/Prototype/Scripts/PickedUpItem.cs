using UnityEngine;
using System;

namespace SAGAMES.RogueSmash.Prototype.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class PickedUpItem : MonoBehaviour
    {
        #region Variables

        private Action<GameObject> onPickedUp;

        #endregion

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                Debug.Log("Entered");
                if (onPickedUp != null)
                {
                    onPickedUp.Invoke(other.gameObject);
                }
            }
        }
        #endregion

        #region Class Methods

        public void Init(Action<GameObject> onPickedUp)
        {
            this.onPickedUp = onPickedUp;
        }

        #endregion
    }
    //By Sean González
}

using System;
using SAGAMES.GameFramework.ResourceSystem.Interfaces;
using UnityEngine;

namespace SAGAMES.GameFramework.ResourceSystem
{
    public class Health : IResource
    {

        #region Variables

        private float currentHealth;
        public event Action<float> OnValueChanged;
        public float CurrentValue
        {
            get
            {
                return currentHealth;
            }
        }

        #endregion
        #region Constructors

        public Health(float _initialValue)
        {
            currentHealth = _initialValue;
        }

        #endregion
        #region Contract Methods

        public float Add(float _amount)
        {
            currentHealth += _amount;
            if (OnValueChanged != null)
            {
                OnValueChanged.Invoke(currentHealth);
            }
            return currentHealth;
        }

        public float Remove(float _amount)
        {
            currentHealth -= _amount;
            if (OnValueChanged != null)
            {
                OnValueChanged.Invoke(currentHealth);
            }
            return currentHealth;
        }

        #endregion
    }
}
//By Sean González

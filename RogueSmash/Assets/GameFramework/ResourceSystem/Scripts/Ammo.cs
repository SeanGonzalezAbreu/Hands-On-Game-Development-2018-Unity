using System;
using SAGAMES.GameFramework.ResourceSystem.Interfaces;
using UnityEngine;

namespace SAGAMES
{
    public class Ammo : IResource
    {
        #region Variables

        private float currentAmmo;
        public float CurrentValue { get { return currentAmmo; } }

        #endregion
        #region Constructors

        public Ammo(float _initialValues)
        {
            currentAmmo = _initialValues;
        }

        #endregion
        #region Contract Methods


        public event Action<float> OnValueChanged;

        public float Add(float _amount)
        {
            currentAmmo += _amount;
            if (OnValueChanged != null)
            {
                OnValueChanged.Invoke(currentAmmo);
            }
            return currentAmmo;
        }

        public float Remove(float _amount)
        {
            currentAmmo -= _amount;
            if (OnValueChanged != null)
            {
                OnValueChanged.Invoke(currentAmmo);
            }
            return currentAmmo;
        }

        #endregion
    }
}
//By Sean González

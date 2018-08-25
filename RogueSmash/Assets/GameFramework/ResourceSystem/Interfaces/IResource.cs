using System;
using UnityEngine;

namespace SAGAMES.GameFramework.ResourceSystem.Interfaces
{
    public interface IResource
    {
        #region Contract Methods

        event Action<float> OnValueChanged;
        float Add(float _amount);
        float Remove(float _amount);
        float CurrentValue { get; }

        #endregion
    }
}
//By Sean González

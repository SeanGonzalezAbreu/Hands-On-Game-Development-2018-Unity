using System;
using System.Collections.Generic;
using UnityEngine;

namespace SAGAMES.GameFramework.ProgressSystem
{
    public class ProgressTracker : MonoBehaviour
    {
        #region Variables

        private Dictionary<string, float> trackables = new Dictionary<string, float>();

        public event Action<string, float> onValueChanged;

        #endregion

        #region Class Methods

        public void RegisterIncrementalTrackable(string _id)
        {
            trackables[_id] = 0;
        }

        public void ReportIncrementalProgress(string _id, float _value)
        {
            trackables[_id] += _value;
            if (onValueChanged != null)
            {
                onValueChanged(_id, trackables[_id]);
            }
        }
        #endregion
    }
}
//By Sean González

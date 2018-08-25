using UnityEngine;
using System.Collections.Generic;
using SAGAMES.GameFramework.SaveSystem;
using SAGAMES.GameFramework.ProgressSystem;
using System;

namespace SAGAMES.RogueSmash.Achievements
{
    public class AchievementTracker : MonoBehaviour
    {
        #region Variables

        public struct Achievement
        {
            private float requiredValue;
            private string message;
            public Achievement(float _requiredValue, string _message) : this()
            {
                this.requiredValue = _requiredValue;
                this.message = _message;
            }
            public string Message
            {
                get { return message; }
            }
            public float RequiredValue
            {
                get { return requiredValue; }
            }
        }

        private ProgressTracker progressTracker;
        //private SaveSystem saveSystem; Use this to save achievements
        private Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

        #endregion

        #region Unity Methods

        private void Start()
        {
            //This is test code
            Achievement cheev = new Achievement(10, "Shoot's Fired!");
            achievements["shots_fired"] = cheev;
            progressTracker.RegisterIncrementalTrackable("shots_fired");
        }

        private void Awake()
        {
            progressTracker = new ProgressTracker();
            //saveSystem = new SaveSystem();
            progressTracker.onValueChanged += OnProgressUpdated;
        }


        #endregion

        #region Class Methods

        public void ReportProgress(string _id, float _value)
        {
            progressTracker.ReportIncrementalProgress(_id, _value);
        }

        private void OnProgressUpdated(string _id, float _value)
        {
            if (achievements.ContainsKey(_id))
            {
                if (_value >= achievements[_id].RequiredValue)
                {
                    Debug.Log(string.Format("ACHIEVEMENT EARNED: {0}", achievements[_id].Message));
                    achievements.Remove(_id);
                }
            }
        }

        #endregion
    }
}
//By Sean González

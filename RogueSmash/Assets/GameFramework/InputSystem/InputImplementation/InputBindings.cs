using UnityEngine;
using System.Collections.Generic;
using System;

namespace SAGAMES.GameFramework.InputManagement
{
    public class InputBindings
    {
        #region Protected Variables

        protected Dictionary<string, KeyCode> keyBindings = new Dictionary<string, KeyCode>();

        #endregion
        #region Constructor

        public InputBindings()
        {
            SetupBindings();
        }

        #endregion
        #region Class Methods

        public Dictionary<string, KeyCode> KeyBindings
        {
            get { return keyBindings; }
        }


        protected virtual void SetupBindings()
        {
        }
        #endregion
    }
}
//By Sean González

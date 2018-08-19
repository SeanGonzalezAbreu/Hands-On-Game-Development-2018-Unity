using System;
using System.Collections.Generic;
using SAGAMES.GameFramework.InputSystem.Interfaces;
using UnityEngine;

namespace SAGAMES.GameFramework.InputManagement
{
    public class InputManager : IInputManager
    {
        #region Protected Variables

        protected InputBindings inputBindings;
        protected IMouseInputHandler mouseInputHandler;
        protected Dictionary<string, Action> actionMap = new Dictionary<string, Action>();


        #endregion
        #region Constructor

        public InputManager(InputBindings _inputBindings, IMouseInputHandler _mouseInputHandler)
        {
            this.inputBindings = _inputBindings;
            this.mouseInputHandler = _mouseInputHandler;
        }

        #endregion
        #region Contract Methods

        public void AddActionToBinding(string _binding, Action _action)
        {
            actionMap.Add(_binding, _action);
        }

        public float GetAxis(string _axisName)
        {
            return Input.GetAxis(_axisName);
        }

        public bool GetButton(string _buttonName)
        {
            return Input.GetButton(_buttonName);
        }

        public Vector2 GetMouseVector()
        {
            return mouseInputHandler.GetInput();
        }

        #endregion
        #region Class Methods

        public void CheckForInput()
        {
            foreach (var kvp in inputBindings.KeyBindings)
            {
                if (Input.GetKeyDown(kvp.Value))
                {
                    Action action;
                    actionMap.TryGetValue(kvp.Key, out action);
                    if (action != null)
                    {
                        action.Invoke();
                    }
                }
            }
        }

        #endregion
    }
}
//By Sean González

using UnityEngine;

namespace SAGAMES.GameFramework.InputManagement
{
    public class SampleBindings : InputBindings
    {
        #region Inherited Method

        protected override void SetupBindings()
        {
            base.SetupBindings();
            keyBindings.Add("Shoot", KeyCode.Mouse0);
        }

        #endregion
    }
}
//By Sean González

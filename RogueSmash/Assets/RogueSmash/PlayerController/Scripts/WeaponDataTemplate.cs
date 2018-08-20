using UnityEngine;

namespace SAGAMES.RogueSmash.PlayerController.Scripts
{
    [CreateAssetMenu(fileName = "New WeaponDataTemplate", menuName = "SAGAMES/Data/Create Data Weapon Template")]
    public class WeaponDataTemplate : ScriptableObject
    {
        #region Variables

        [SerializeField]
        private WeaponData weaponData;

        public WeaponData WeaponData
        {
            get { return weaponData; }
        }
        #endregion
    }
}
//By Sean González

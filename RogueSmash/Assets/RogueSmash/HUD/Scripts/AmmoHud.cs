using System;
using SAGAMES.GameFramework.ResourceSystem.Interfaces;
using SAGAMES.RogueSmash.PlayerController;
using UnityEngine;
using TMPro;

namespace SAGAMES.RogueSmash.HUD
{
    public class AmmoHud : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TextMeshProUGUI hudText;
        private float maxAmmo;
        private IResource ammo;
        #endregion

        #region Unity Callbacks

        private void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");
            SampleCharacterController scc = player.GetComponent<SampleCharacterController>();
            ammo = scc.Weapon.Ammo;
            maxAmmo = ammo.CurrentValue;
            ammo.OnValueChanged += OnValueChanged;
            hudText.text = string.Format("{0} / {1}", ammo.CurrentValue, maxAmmo);
        }

        #endregion

        #region Class Methods

        private void OnValueChanged(float _amount)

        {
            hudText.text = string.Format("{0} / {1}", _amount, maxAmmo);
        }

        #endregion
    }
}
//By Sean González

using System;
using SAGAMES.GameFramework.InputManagement;
using SAGAMES.GameFramework.InputSystem.Interfaces;
using SAGAMES.RogueSmash.PlayerController.Scripts;
using SAGAMES.RogueSmash.Weapons;
using UnityEngine;

namespace SAGAMES.SandBox.Scripts
{
    public class SampleCharacterController : MonoBehaviour
    {
        #region Variables

        [Header("Data Templates")]
        [SerializeField] private CharacterDataTemplate characterDataTemplate;
        [SerializeField] private WeaponDataTemplate weaponDataTemplate;

        [Header("Other")]
        private InputManager inputManager;
        private IWeapon weapon;
        [SerializeField] private Transform weaponBarrel;
        #endregion

        #region Unity Methods

        private void Start()
        {
            inputManager = new InputManager(new SampleBindings(), new RadialMouseInputHandler());
            inputManager.AddActionToBinding("Shoot", Shoot);
            weapon = new Pistol(weaponDataTemplate.WeaponData, weaponBarrel.gameObject);
        }


        private void FixedUpdate()
        {
            CheckForInput();
        }

        #endregion

        #region Class Methods

        private void Shoot()
        {
            weapon.Shoot();
        }

        private void CheckForInput()
        {
            inputManager.CheckForInput();
            Vector2 mouseInput = inputManager.GetMouseVector();
            Quaternion lookRotation = Quaternion.Euler(mouseInput);
            transform.rotation = lookRotation;

            Vector3 input = Vector3.zero;
            input.x = inputManager.GetAxis("Horizontal");
            input.z = inputManager.GetAxis("Vertical");
            transform.Translate(input * Time.deltaTime * characterDataTemplate.Data.MovementSpeed, Space.World);

        }
        #endregion
    }
}
//By Sean González

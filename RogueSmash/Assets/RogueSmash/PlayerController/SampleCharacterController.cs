using SAGAMES.GameFramework.InputManagement;
using SAGAMES.GameFramework.InputSystem.Interfaces;
using SAGAMES.RogueSmash.Achievements;
using SAGAMES.RogueSmash.PlayerController.Scripts;
using SAGAMES.RogueSmash.Weapons;
using UnityEngine;

namespace SAGAMES.RogueSmash.PlayerController
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
        private AchievementTracker tracker;
        private Rigidbody rb;

        #endregion

        #region Unity Methods

        private void Start()
        {
            inputManager = new InputManager(new SampleBindings(), new RadialMouseInputHandler());
            inputManager.AddActionToBinding("Shoot", Shoot);
            weapon = new Pistol(weaponDataTemplate.WeaponData, weaponBarrel.gameObject);
        }
        private void Awake()
        {
            tracker = FindObjectOfType<AchievementTracker>();
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            CheckForInput();
        }

        #endregion

        #region Class Methods

        private void Shoot()
        {
            if (weapon.Shoot()) tracker.ReportProgress("shots_fired", 1.0f);
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
            //transform.Translate(input * Time.deltaTime * characterDataTemplate.Data.MovementSpeed, Space.World);
            rb.velocity = input * characterDataTemplate.Data.MovementSpeed;

        }
        #endregion
    }
}
//By Sean González

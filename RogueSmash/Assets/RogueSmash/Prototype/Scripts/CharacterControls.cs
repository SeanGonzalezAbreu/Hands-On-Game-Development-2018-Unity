using UnityEngine;
namespace SAGAMES.RogueSmash.Prototype.Scripts
{
    public class CharacterControls : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject actor;
        [SerializeField] private float moveSpeedModifier = 3f;
        private Vector3 mousePosition;
        private Vector3 lookDirection;
        [SerializeField] private WeaponController.WeaponControllerData weaponData;
        private WeaponController weaponController;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            weaponController = new WeaponController(weaponData);
        }
        void FixedUpdate()
        {
            HandleInput();
        }

        #endregion

        #region Class Methods

        private void HandleInput()
        {
            Quaternion lookRotation = GetMouseInput();
            actor.transform.rotation = lookRotation;
            Vector3 moveDirection = GetKeyInput();
            actor.transform.Translate(moveDirection * Time.deltaTime * moveSpeedModifier, Space.World);
            if (Input.GetButtonDown("Fire1")) weaponController.Use();
        }

        private Vector3 GetKeyInput()
        {
            Vector3 input = Vector3.zero;
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
            return input;
        }

        private Quaternion GetMouseInput()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width / 2, mousePos.y - Screen.height / 2);
            float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
            return rot;
        }
        #endregion
    }
}

//By Sean González
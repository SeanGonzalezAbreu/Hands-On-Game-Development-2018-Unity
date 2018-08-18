using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    #region Public Fields

    [SerializeField] private GameObject actor;
    [SerializeField] private float moveSpeedModifier = 3f;
    private Vector3 mousePosition;
    private Vector3 lookDirection;

    #endregion

    #region Unity Methods
    void Start()
    {

    }

    void FixedUpdate()
    {
        HandleInput();
    }

    #endregion

    #region Private Methods

    private void HandleInput()
    {
        Quaternion lookRotation = GetMouseInput();
        actor.transform.rotation = lookRotation;
        Vector3 moveDirection = GetKeyInput();
        actor.transform.Translate(moveDirection * Time.deltaTime * moveSpeedModifier, Space.World);
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
//By Sean González
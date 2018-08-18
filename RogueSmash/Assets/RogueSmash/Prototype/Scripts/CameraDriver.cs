using System;
using UnityEngine;

public class CameraDriver : MonoBehaviour
{
    #region Public Fields

    [SerializeField] private Transform target;
    [SerializeField] private float verticalOffset;
    [SerializeField] private float followOffset;
    [SerializeField] private float followSpeed = 2.0f;
    [SerializeField] private bool shouldLookAtTarget;

    private Vector3 targetPosition;
    private Vector3 targetDirection;


    #endregion

    #region Unity Methods
    void Start()
    {

    }

    void FixedUpdate()
    {
        Move();
        Look();
    }

    #endregion

    #region Private Methods
    #endregion

    private void Look()
    {
        if (shouldLookAtTarget) transform.LookAt(target);
    }

    private void Move()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + verticalOffset, target.transform.position.z - followOffset);
        targetDirection = targetPosition - transform.position;
        transform.position += targetDirection * Time.deltaTime * followSpeed;
    }
}
//By Sean González
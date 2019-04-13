using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [Header("Parametros Modificables")]
    [Tooltip("Distancia en z del personaje")]
    public float dstFromTarget = 2;
    [Tooltip("Sensibilidad del mouse")]
    public float mouseSensitivity = 10;
    [Tooltip("Suavisado al mover el mouse")]
    public float rotationSmoothTime = .1f;
    [Tooltip("Hasta donde baja y sube la camara")]
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    [Tooltip("Bloquear mouse")]
    public bool lockCursor;

    [Header("Parametros Fijos")]
    [Tooltip("Objetivo a seguir (CameraFollow)")]
    public Transform target;

    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private float yaw;
    private float pitch;

    [Header("Aun no se usan")]
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;




    public float compensationOffset = 0.2f;
    private Vector3[] viewFrustum;
    private Vector3 nearClipDimensions = Vector3.zero; // width, height, radius
    // Start is called before the first frame update
    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 posFinal = Vector3.zero;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        posFinal = target.position - transform.forward * dstFromTarget;
        //CompensateForWalls(target.position, ref posFinal);
        transform.position = posFinal;

    }



    private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    {
        // Compensate for walls between camera
        float distance;
        dollyDir = toTarget.normalized;
        distance = toTarget.magnitude;
        RaycastHit wallHit = new RaycastHit();
        if (Physics.Linecast(fromObject, toTarget, out wallHit))
        {
            Debug.DrawRay(wallHit.point, wallHit.normal, Color.red);
            //toTarget =  wallHit.point;
            toTarget = wallHit.point ;
        }

    }
}

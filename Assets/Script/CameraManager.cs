using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraType
{

THIRD,
FIRST

}

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [Header("Parametros Modificables")]

    [Tooltip("Distancia en z del personaje")]
    public float dstFromTarget = 2;
    [Tooltip("Distancia en z del personaje primeraPersona")]
    public float dstFromTargetFirst = 2;

    [Tooltip("Sensibilidad del mouse")]
    public float mouseSensitivity = 10;
    [Tooltip("Sensibilidad del mouse PP")]
    public float mouseSensitivityPP = 0.1f;
    [Tooltip("Suavisado al mover el mouse")]
    public float rotationSmoothTime = .1f;
    [Tooltip("Hasta donde baja y sube la camara")]
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    [Tooltip("Hasta donde baja y sube la camara pp")]
    public Vector2 pitchMinMaxPP = new Vector2(-20, 65);

    [Tooltip("Bloquear mouse")]
    public bool lockCursor = true;

    [Header("Parametros Fijos")]
    [Tooltip("Objetivo a seguir (CameraFollow)")]
    public Transform target;
    [Tooltip("Objetivo a seguir primeraPersona (CameraFollow)")]
    public Transform targetPrimera;

    public CameraType camVar = CameraType.THIRD;

    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    public Camera cam;
    public Camera camPP;

    private float yaw;
    private float pitch;

    [Header("Aun no se usan")]
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;

    private float turnSmoothVelocity;


    public float compensationOffset = 0.2f;
    private Vector3[] viewFrustum;
    private Vector3 nearClipDimensions = Vector3.zero; // width, height, radius

    private Vector3 camInit;
    private Vector3 camInitPP;

    internal CameraType CamVar { get => camVar; set => camVar = value; }
    private bool cameraFirst;
    private void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

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
        if (CamVar == CameraType.THIRD)
        {
            cam.enabled = true;
            camPP.enabled = false;

            CameraFollow();
            cameraFirst = true;

        }
        if (CamVar == CameraType.FIRST)
        {
            cam.enabled = false;
            camPP.enabled = true;

            if (cameraFirst)
            {
                ResetCameraPP();
                cameraFirst = false;
            }
            CameraFirst();
        }
    }


    public void ResetCameraPP()
    {
        //yaw = 0;
        //pitch = 0;
        Vector3 posFinal = Vector3.zero;
        camPP.transform.LookAt(targetPrimera);

        posFinal = targetPrimera.position - targetPrimera.forward * dstFromTargetFirst;
        camPP.transform.position = posFinal;
        camPP.transform.forward = targetPrimera.parent.transform.forward;



    }

    private void CameraFirst()
    {
        Vector3 posFinal = Vector3.zero;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivityPP;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivityPP;
        pitch = Mathf.Clamp(pitch, pitchMinMaxPP.x, pitchMinMaxPP.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        camPP.transform.eulerAngles = currentRotation;

        posFinal = targetPrimera.position - camPP.transform.forward * dstFromTargetFirst;
        for (float i = 0; i < 1; i += 0.1f)
        {
            transform.position = Vector3.Lerp(camPP.transform.position, posFinal, i);
        }
    }

    private void CameraFollow()
    {

        Vector3 posFinal = Vector3.zero;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        cam.transform.eulerAngles = currentRotation;


        posFinal = target.position - cam.transform.forward * dstFromTarget;
        CompensateForWalls(target.position, ref posFinal);

        for (float i = 0; i < 1; i += 0.1f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, posFinal, i );
        }
    }
    private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    {
        // Compensate for walls between camera
        float distance;
        Vector3 vAux = Vector3.zero;
        distance = toTarget.magnitude;
        RaycastHit wallHit = new RaycastHit();
        Debug.DrawRay(fromObject, toTarget, Color.red);
        if (Physics.Linecast(fromObject, toTarget, out wallHit))
        {
            //Debug.DrawRay(wallHit.point, wallHit.normal, Color.red);
            //toTarget =  wallHit.point;

            Debug.DrawLine(fromObject, (fromObject.magnitude - wallHit.point.magnitude) * toTarget.normalized, Color.blue);
            distance = Mathf.Clamp(wallHit.distance, 0, wallHit.distance);
            vAux = (fromObject.magnitude - distance + 0.8f) * wallHit.point.normalized;

            toTarget = vAux;

        }

    }
}

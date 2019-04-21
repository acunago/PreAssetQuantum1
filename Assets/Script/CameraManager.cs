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

    [Header("Parametros Modificables Mediano")]

    [Tooltip("Distancia en z del personaje")]
    public float dstFromTarget = 2;
    [Tooltip("Sensibilidad del mouse")]
    public float mouseSensitivity = 10;
    [Tooltip("Suavisado al mover el mouse")]
    public float rotationSmoothTime = .1f;
    [Tooltip("Hasta donde baja y sube la camara")]
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    [Tooltip("Objetivo a seguir (CameraFollow)")]
    public Transform target;

    [Header("Parametros Modificables Pequeño")]

    [Tooltip("Distancia en z del personaje")]
    public float dstFromTargetPequeño = 2;
    [Tooltip("Sensibilidad del mouse")]
    public float mouseSensitivityPequeño = 10;
    [Tooltip("Suavisado al mover el mouse")]
    public float rotationSmoothTimePequeño = .1f;
    [Tooltip("Hasta donde baja y sube la camara")]
    public Vector2 pitchMinMaxPequeño = new Vector2(-40, 85);
    [Tooltip("Objetivo a seguir (CameraFollow)")]
    public Transform targetPequeño;

    [Header("Parametros Modificables Grande")]

    [Tooltip("Distancia en z del personaje")]
    public float dstFromTargeGrande = 2;
    [Tooltip("Sensibilidad del mouse")]
    public float mouseSensitivityGrande = 10;
    [Tooltip("Suavisado al mover el mouse")]
    public float rotationSmoothTimeGrande = .1f;
    [Tooltip("Hasta donde baja y sube la camara")]
    public Vector2 pitchMinMaxGrande = new Vector2(-40, 85);
    [Tooltip("Objetivo a seguir (CameraFollow)")]
    public Transform targetGrande;



    [Header("Parametros Fijos")]

    [Tooltip("Bloquear mouse")]
    public bool lockCursor = true;

    public CameraType camVar = CameraType.THIRD;
    public Camera cam;
    public float velocidadCamara = 0.1f;

    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    public transformations state = transformations.NORMAL;

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

        switch (state)
        {
            case transformations.GIGANT:
                CameraFollowGigant();
                break;
            case transformations.NORMAL:
                CameraFollow();
                break;
            case transformations.SMALL:
                CameraFollowSmall();
                break;
            default:
                break;
        }
    }



    private void CameraFollowSmall()
    {

        Vector3 posFinal = Vector3.zero;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivityPequeño;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivityPequeño;
        pitch = Mathf.Clamp(pitch, pitchMinMaxPequeño.x, pitchMinMaxPequeño.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTimePequeño);
        cam.transform.eulerAngles = currentRotation;


        posFinal = targetGrande.position - cam.transform.forward * dstFromTargetPequeño;
        CompensateForWalls(targetPequeño.position, ref posFinal);

        cam.transform.position = Vector3.Lerp(cam.transform.position, posFinal, velocidadCamara);


    }
    private void CameraFollowGigant()
    {
        Vector3 posFinal = Vector3.zero;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivityGrande;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivityGrande;
        pitch = Mathf.Clamp(pitch, pitchMinMaxGrande.x, pitchMinMaxGrande.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTimeGrande);
        cam.transform.eulerAngles = currentRotation;


        posFinal = targetGrande.position - cam.transform.forward * dstFromTargeGrande;
        CompensateForWalls(targetGrande.position, ref posFinal);

        cam.transform.position = Vector3.Lerp(cam.transform.position, posFinal, velocidadCamara);
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

        cam.transform.position = Vector3.Lerp(cam.transform.position, posFinal, velocidadCamara);
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
            if (wallHit.transform.gameObject.layer != 14)
            {
                Debug.DrawLine(fromObject, (fromObject.magnitude - wallHit.point.magnitude) * toTarget.normalized, Color.blue);
                distance = Mathf.Clamp(wallHit.distance, 0, wallHit.distance);
                vAux = (fromObject.magnitude - distance + 0.8f) * wallHit.point.normalized;

                toTarget = vAux;
            }
        }
    }
}


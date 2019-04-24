using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Comport
{
    IDDLE,
    AIR,
    MOVE,
    CARGANDO

}


public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    [Tooltip("Velocidad caminar")]
    public float walkSpeed;
    [Tooltip("Velocidad Correr")]
    public float runSpeed;
    [Tooltip("Velocidad de Rotacion")]
    public float RotationVelocity = 1f;
    [Tooltip("Fuerza de Salto")]
    public float jumpForce = 5;

    public Comport actions;

    public Rigidbody rb;
    public float currentSpeed;

    public float desiredRotationSpeed = 0.1f;

    public float rotationDegreePerSecond = 200f;


    public Animator animator;
    Transform cameraT;
    public Vector3 inputDir;
    public Vector3 desiredMoveDirection;

    public bool blSoltarCaja = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        animator = transform.GetComponent<Animator>();
        cameraT = Camera.main.transform;
        actions = Comport.IDDLE;
    }

    // Update is called once per frame


    #region movement
    public virtual void Jump()
    {

        if (actions == Comport.AIR) return;
        actions = Comport.AIR;
        rb.velocity = Vector3.zero;
        rb.AddForce((transform.up) * jumpForce, ForceMode.Impulse);

    }

    public virtual void Move(Vector3 dir)
    {




        inputDir = dir.normalized;

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.z;

        currentSpeed = targetSpeed;



        Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (dir.x < 0f ? -1f : 1f), 0f), Mathf.Abs(dir.x * RotationVelocity));
        Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
        transform.rotation = (transform.rotation * deltaRotation);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        animator.SetFloat("speed", currentSpeed);


    }

    public virtual void Move(Vector3 dir, Camera cam)
    {
        //inputDir = dir.normalized;

        //bool running = Input.GetKey(KeyCode.LeftShift);
        //float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.z;
        //Vector3 dirCamForward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);

        //currentSpeed = targetSpeed;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirCamForward), desiredRotationSpeed);
        //transform.position += transform.forward * currentSpeed * Time.deltaTime;
    }
    public virtual void Move(Vector3 dir, Transform cam)
    {
        //if (actions == Comport.AIR) return;
        if (actions == Comport.CARGANDO)
        {
            if (dir.x != 0 && dir.z < 0)
            {
                blSoltarCaja = true;
            }
        }

        float targetSpeed = 0f;
        inputDir = dir.normalized;

        bool running = Input.GetKey(KeyCode.LeftShift);

        Vector3 dirCamForward = new Vector3(cam.forward.x, 0, cam.forward.z);
        Vector3 dirCamRigth = new Vector3(cam.right.x, 0, cam.right.z);
        Vector3 sumNorm = Vector3.zero;




        Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (dir.x < 0f ? -1f : 1f), 0f), Mathf.Abs(dir.x * RotationVelocity));
        Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);

        if (dir.normalized.z != 0)
        {

            targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.z;
            sumNorm += dirCamForward.normalized * dir.normalized.z;
        }

        if (dir.normalized.x != 0)
        {

            sumNorm += dirCamRigth.normalized * dir.normalized.x;
            targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.x;
        }

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(sumNorm), desiredRotationSpeed);
        }
        currentSpeed = Mathf.Abs(targetSpeed) * Time.deltaTime;

        //transform.position += transform.forward * currentSpeed * Time.deltaTime;

        //Debug.Log()

        rb.MovePosition(transform.position + transform.forward  * currentSpeed);

        animator.SetFloat("speed", Mathf.Abs(targetSpeed));


    }
    #endregion
    private void OnCollisionEnter(Collision collision)
    {
            actions = Comport.IDDLE;

    }

}

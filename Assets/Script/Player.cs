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
        if (actions == Comport.CARGANDO) return;


        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        actions = Comport.AIR;
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

    public virtual void Move(Vector3 dir, Transform cam)
    {
        float targetSpeed = 0f;
        inputDir = dir.normalized;

        bool running = Input.GetKey(KeyCode.LeftShift);

        Vector3 dirCamForward = new Vector3(cam.forward.x,0, cam.forward.z);
        Vector3 dirCamRigth = new Vector3(cam.right.x, 0, cam.right.z); ;




        Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (dir.x < 0f ? -1f : 1f), 0f), Mathf.Abs(dir.x * RotationVelocity));
        Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);

        if(dir.normalized.z == 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirCamForward * dir.normalized.z), desiredRotationSpeed);
              targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.z;

        }
        else
        {
            if (dir.normalized.x != 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirCamRigth * dir.normalized.x), desiredRotationSpeed);
                targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.x;
            }
        }

        currentSpeed = Mathf.Abs(targetSpeed);
        transform.position += transform.forward * currentSpeed * Time.deltaTime;



        animator.SetFloat("speed", currentSpeed);


    }
    #endregion
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            actions = Comport.IDDLE;

        }

    }
}

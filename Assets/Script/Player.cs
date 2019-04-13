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

    public Comport actions = Comport.IDDLE;

    public Rigidbody rb;
    public float currentSpeed;



    public float rotationDegreePerSecond = 200f;


    public Animator animator;
    Transform cameraT;
    public Vector3 inputDir;


    // Start is called before the first frame update
    void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        animator = transform.GetComponent<Animator>();
        cameraT = Camera.main.transform;

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

        animator.SetFloat("speed", dir.z);


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

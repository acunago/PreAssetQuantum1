using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum transformations
{
    GIGANT,
    NORMAL,
    SMALL

}

public enum Comport
{
    IDDLE,
    AIR,
    CARGANDO

}

public class HeroBody : MonoBehaviour
{
    [Header("Movimiento")]
    [Tooltip("Velocidad caminar")]
    public float walkSpeed ;
    [Tooltip("Velocidad Correr")]
    public float runSpeed ;
    [Tooltip("Velocidad de Rotacion")]
    public float RotationVelocity = 1f;
    [Tooltip("Fuerza de Salto")]
    public float jumpForce = 5;
    [Header("Control")]

    public transformations state = transformations.NORMAL;
    public Comport actions = Comport.IDDLE;
    public Rigidbody rb;
    private float currentSpeed;

    private Vector3 inputDir;
    private Vector3 initcale;



    private BoxScript bxSript;
    private float rotationDegreePerSecond = 200f;

    Animator animator;
    Transform cameraT;



    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        initcale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Big()
    {
        if (state != transformations.GIGANT)
        {
            transform.localScale = initcale;
            transform.localScale += new Vector3(0.8F, 0.8F, 0.8F);
            state = transformations.GIGANT;
        }
    }

    public void Small()
    {
        if (state != transformations.SMALL)
        {
            transform.localScale = initcale;
            transform.localScale -= new Vector3(0.8F, 0.8F, 0.8F);
            state = transformations.SMALL;

        }
    }

    public void Normal()
    {
        if(state != transformations.NORMAL) {
            transform.localScale = initcale;
            state = transformations.NORMAL;
        }

    }
    

    public void Jump()
    {
        if(state == transformations.GIGANT) return;
        if(actions == Comport.AIR) return;
        if(actions == Comport.CARGANDO) return;
        
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        actions = Comport.AIR;
    }

    public void Move(Vector3 dir) {


        inputDir = dir.normalized;

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.z;

        currentSpeed = targetSpeed;
        
        Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (dir.x < 0f ? -1f : 1f), 0f), Mathf.Abs(dir.x * RotationVelocity));
        Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
        this.transform.rotation = (this.transform.rotation * deltaRotation);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        animator.SetFloat("speed", dir.magnitude);


    }
    public void Activate()
    {

        RaycastHit hit;
        //if (state == transformations.GIGANT) {
        if (actions == Comport.CARGANDO)
        {
            bxSript.Soltar();
            actions = Comport.IDDLE;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            if (hit.transform.gameObject.layer == 10)
            {
                bxSript = hit.transform.GetComponent<BoxScript>();
                bxSript.Agarre();
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
                Debug.Log("Did Hit");
                actions = Comport.CARGANDO;
            }
        }


        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            actions = Comport.IDDLE;

        }

    }
}

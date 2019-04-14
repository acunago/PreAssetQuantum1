using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum transformations
{
    GIGANT,
    NORMAL,
    SMALL

}

public class HeroBody : Player
{

    [Header("Control")]
    public transformations state = transformations.NORMAL;


    private Vector3 initcale;
    private BoxScript bxSript;
    private LeverScript lvrSript;

    public Text txtClick;
    private float auxWalkSpeed;
    private float auxRunSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initcale = transform.localScale;

        auxWalkSpeed = walkSpeed;
        auxRunSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region transformations
    public void Big()
    {
        if (state != transformations.GIGANT)
        {
            walkSpeed = auxWalkSpeed * 0.7f;
            runSpeed = walkSpeed;

            transform.localScale = initcale;
            transform.localScale += new Vector3(0.8F, 0.8F, 0.8F);
            state = transformations.GIGANT;
        }
    }
    public void Small()
    {
        if (state != transformations.SMALL)
        {
            walkSpeed = auxWalkSpeed * 0.5f;
            runSpeed = auxRunSpeed * 0.5f;

            transform.localScale = initcale;
            transform.localScale -= new Vector3(0.8F, 0.8F, 0.8F);
            state = transformations.SMALL;

        }
    }
    public void Normal()
    {
        if(state != transformations.NORMAL) {

            walkSpeed = auxWalkSpeed;
            runSpeed = auxRunSpeed;

            transform.localScale = initcale;
            state = transformations.NORMAL;
        }

    }
    #endregion

    public override void Jump()
    {
        if(state == transformations.GIGANT) return;
        if(actions == Comport.AIR) return;
        if(actions == Comport.CARGANDO) return;
        
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        actions = Comport.AIR;
    }

    public void Activate(RaycastHit hit)
    {
        Debug.Log("Esto funciona");
        if (hit.transform.gameObject.layer == 10)
        {
            if(state!= transformations.GIGANT) { return; }
            bxSript = hit.transform.GetComponent<BoxScript>();
            bxSript.Agarre();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
            Debug.Log("Did Hit");
            actions = Comport.CARGANDO;
            animator.SetBool("Box", true);
        }
        if (hit.transform.gameObject.layer == 12)
        {
            lvrSript = hit.transform.GetComponent<LeverScript>();
            lvrSript.SetActive();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.cyan);
            Debug.Log("Did Hit lever");

        }
    }
    public void SoltarCaja()
    {
        if (actions == Comport.CARGANDO)
        {
            bxSript.Soltar();
            actions = Comport.IDDLE;
            animator.SetBool("Box", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            actions = Comport.IDDLE;

        }

    }
}

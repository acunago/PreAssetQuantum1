using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateCaja
{
    AGARRADO,
    PISO


}
public class BoxScript : MonoBehaviour
{
    // Start is called before the first frame update

    public StateCaja state = StateCaja.PISO;
    public Animator animator;
    Rigidbody rb;
    
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.mass = 10000;
    }

    private void Update()
    {

        if (state == StateCaja.AGARRADO)
        {

            {


                if (Input.GetKey(KeyCode.W))
                {

                    rb.mass = 700;


                }


            }
        }

    }
    public void Agarre()
    {
        state = StateCaja.AGARRADO;
        animator.SetBool("SoltarCaja", false);
    }
    public void Soltar()
    {

    }
    private void OnCollisionExit(Collision collision)
    {
        rb.mass = 10000;
        animator.SetBool("SoltarCaja", true);
        state = StateCaja.PISO;
    }
}

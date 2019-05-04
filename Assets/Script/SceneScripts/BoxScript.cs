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
    public GameObject character;
    Rigidbody rb;
    
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.mass = 10000;
    }

    private void Update()
    {
        RaycastHit wallHit;

        if (state == StateCaja.AGARRADO)
        {
            Debug.Log("va");
            if (Input.GetKey(KeyCode.W))
            {

                rb.mass = 700;
            }
            Debug.DrawRay(character.transform.position, character.transform.forward * 10, Color.red);

            float dot = Vector3.Dot(character.transform.forward, (transform.position - character.transform.position).normalized);
            if (dot > 0.7f) { Debug.Log("Quite facing"); } else
            {

                rb.mass = 10000;
                animator.SetBool("SoltarCaja", true);
                state = StateCaja.PISO;

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

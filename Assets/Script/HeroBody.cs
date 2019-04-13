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

    public Text txtClick;

    // Start is called before the first frame update
    void Start()
    {
        initcale = transform.localScale;
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
            txtClick.gameObject.SetActive(true);
            bxSript = hit.transform.GetComponent<BoxScript>();
            bxSript.Agarre();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
            Debug.Log("Did Hit");
            actions = Comport.CARGANDO;
        }

    }

    public void SoltarCaja()
    {
        if (actions == Comport.CARGANDO)
        {
            bxSript.Soltar();
            actions = Comport.IDDLE;
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

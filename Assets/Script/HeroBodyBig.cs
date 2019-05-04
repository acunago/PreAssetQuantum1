﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBodyBig : Player
{
    private BoxScript bxSript;
    public GameObject Hands;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blSoltarCaja)
        {
            SoltarCaja();
        }
    }

    public void Activate(RaycastHit hit)
    {
        if (hit.transform.gameObject.layer == 10)
        {

            bxSript = hit.transform.GetComponent<BoxScript>();
            bxSript.Agarre();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);

            actions = Comport.CARGANDO;
            animator.SetBool("box", true);
            blSoltarCaja = false;
        }
    }

    public void SoltarCaja()
    {
        if (actions == Comport.CARGANDO)
        {
            
            actions = Comport.IDDLE;
            animator.SetBool("box", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {


    }

}

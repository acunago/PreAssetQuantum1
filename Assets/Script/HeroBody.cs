using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HeroBody : Player
{

    private Vector3 initcale;
    private BoxScript bxSript;
    private LeverScript lvrSript;



    private float auxWalkSpeed;
    private float auxRunSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate(RaycastHit hit)
    {
        if (hit.transform.gameObject.layer == 12)
        {
            lvrSript = hit.transform.GetComponent<LeverScript>();
            lvrSript.SetActive();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.cyan);
            

        }
    }


}

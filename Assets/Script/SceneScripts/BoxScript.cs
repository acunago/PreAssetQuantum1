using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CajaState
{
    AGARRADO,
    PISO

}

public class BoxScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform hands;
    public CajaState posCaja;
    public float masaMovible;
    private Rigidbody rb;
    private float masaBase;
    
    void Start()
    {
        posCaja = CajaState.PISO;
        rb = transform.GetComponent<Rigidbody>();
        masaBase = rb.mass;

    }

    // Update is called once per frame
    void Update()
    {

        
    }


    public void Agarre()
    {
        rb.mass = masaMovible;
    }
    public void Soltar ()
    {
        rb.mass = masaBase;
    }
}

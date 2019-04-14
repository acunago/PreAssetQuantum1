﻿using System.Collections;
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

    void Start()
    {
        posCaja = CajaState.PISO;
        transform.gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (posCaja == CajaState.AGARRADO)
        {
            transform.position = hands.position;
        }
        
    }


    public void Agarre()
    {
        posCaja = CajaState.AGARRADO;
    }
    public void Soltar ()
    {
        posCaja = CajaState.PISO;
    }
}

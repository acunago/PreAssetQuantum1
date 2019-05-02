﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LeverState
{
    ACTIVE,
    DISABLED
}
public class LeverScript : MonoBehaviour
{
    public GameObject[] interact;
    public LeverState state;

    private Color original;
    private DoorScript doorCall;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        state = LeverState.DISABLED;
        rend = GetComponent<Renderer>();
        original = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetActive()
    {
        if (state == LeverState.ACTIVE)
        {
            state = LeverState.DISABLED;
            
            rend.material.color = original;
            DisableElements();


        }
        else
        {
            state = LeverState.ACTIVE;
            
            rend.material.color = Color.red;
            ActiveElements();
        }

    }

    public void ActiveElements()
    {

        for (int i = 0; i < interact.Length; i++)
        {
            if (interact[i].layer == 16) //puerta
            {
                interact[i].GetComponent<DoorScript>().SetActive();

            }
            else
            {
                if (interact[i].layer == 17) //puente
                {
                    interact[i].GetComponent<BridgeScript>().SetActive();

                }
            }
        }

    }

    public void DisableElements()
    {

        for (int i = 0; i < interact.Length; i++)
        {
            if (interact[i].layer == 16) //puerta
            {
                interact[i].GetComponent<DoorScript>().SetDisabled();

            }
            else
            {
                if (interact[i].layer == 17) //puente
                {
                   interact[i].GetComponent<BridgeScript>().SetDisabled();

                }
            }
        }

    }
}

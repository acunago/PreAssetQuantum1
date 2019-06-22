using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlatformState
{
    ACTIVE,
    DISABLED
}

public class PlatformScript : MonoBehaviour
{
    public GameObject[] interact;
    public PlatformState state;
    public int objects;
    public float objectsToChange = 1;
    public Color keepColour;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (objects >= objectsToChange)
        {

            DisableElements();

        }
        else
        {
            ActiveElements();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 20)
        {
            objects = objects + 1;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer != 20)
        {
            objects = objects - 1;

        }
    }


    public void SetActive()
    {
        if (state == PlatformState.ACTIVE)
        {
            state = PlatformState.DISABLED;


            DisableElements();


        }
        else
        {
            state = PlatformState.ACTIVE;


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
                else
                {
                    if (interact[i].layer == 23) //reja
                    {
                        Debug.Log("reja");
                        interact[i].GetComponent<RejaScript>().SetActive();

                    }
                    else
                    {
                        if (interact[i].layer == 24) //pendulo
                        {

                            interact[i].GetComponent<PenduloScript>().SetActive();

                        }
                        else
                        {
                            if (interact[i].layer == 25) //activo
                            {

                                interact[i].SetActive(true);

                            }
                            else
                            {
                                interact[i].SetActive(true);
                            }
                        }
                    }

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
                else
                {
                    if (interact[i].layer == 23) //reja
                    {
                        Debug.Log("reja");
                        interact[i].GetComponent<RejaScript>().SetDisable();

                    }
                    else
                    {
                        if (interact[i].layer == 24) //pendulo
                        {

                            interact[i].GetComponent<PenduloScript>().SetDisable();

                        }
                        else
                        {
                            if (interact[i].layer == 25) //activo
                            {

                                interact[i].SetActive(false);

                            }
                            else
                            {
                                interact[i].SetActive(false);
                            }
                        }
                    }
                }
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonState
{
    ACTIVE,
    DISABLED
}

public class ButtonScript : MonoBehaviour
{

    public GameObject[] interact;
    public ButtonState state;
    public GameObject Movement;
    public Vector3 rotationAngle;

    public bool isTimmer;
    public float timmer;
    public float actTime;



    // Start is called before the first frame update
    void Start()
    {
        state = ButtonState.DISABLED;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == ButtonState.ACTIVE)
        {

            Movement.transform.GetChild(0).GetComponent<Outline>().enabled = true;
            Movement.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (isTimmer)
            {
                actTime += Time.deltaTime;
                if (timmer <= actTime)
                {
                    SetActive();
                }
            }

        }
        else
        {

            Movement.transform.GetChild(0).GetComponent<Outline>().enabled = false;
            Movement.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        }
    }


    public void SetActive()
    {
        if (state == ButtonState.ACTIVE)
        {
            state = ButtonState.DISABLED;

            actTime = 0;
            DisableElements();


        }
        else
        {
            state = ButtonState.ACTIVE;


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

                            interact[i].GetComponent<PenduloScript>().SetActive();

                        }
                        else
                        {
                            if (interact[i].layer == 25) //activo
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

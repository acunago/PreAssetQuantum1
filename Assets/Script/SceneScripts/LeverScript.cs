using System.Collections;
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
    public GameObject Movement;
    public Transform activePOS;

    public bool isTimmer;
    public float timmer;
    public float actTime;
    public SoundBag snd;

    private Quaternion quatOrignal;
    private Quaternion quatActive;

    // Start is called before the first frame update
    void Start()
    {
        //Movement.transform.rotation = Quaternion.Euler(Movement.transform.rotation.x, Movement.transform.rotation.y, 0);
        state = LeverState.DISABLED;
        quatOrignal = Movement.transform.rotation;
        quatActive = activePOS.rotation;
        snd = transform.gameObject.GetComponent<SoundBag>();
    }

    // Update is called once per frame
    void Update()
    {

        if (state == LeverState.ACTIVE)
        {
            Movement.transform.rotation = Quaternion.Slerp(Movement.transform.rotation, quatActive, 0.2f);
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
            
            Movement.transform.rotation = Quaternion.Slerp(Movement.transform.rotation, quatOrignal, 0.2f);
            Movement.transform.GetChild(0).GetComponent<Outline>().enabled = false;
            Movement.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void SetActive()
    {
        if (snd != null)
        {
            snd.PlaySound();
        }
        if (state == LeverState.ACTIVE)
        {
            state = LeverState.DISABLED;

            actTime = 0;
            DisableElements();


        }
        else
        {
            state = LeverState.ACTIVE;
            ActiveElements();
        }

    }
    public void ActiveElements()
    {

        for (int i = 0; i < interact.Length; i++)
        {
            if (interact[i] != null)
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
                            if (!interact[i].GetComponent<RejaScript>().Old)
                            {
                                interact[i].GetComponent<RejaScript>().SetActive();
                            }
                            else
                            {
                                interact[i].GetComponent<RejaScript>().ChangeStatus();
                            }

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
                        if (!interact[i].GetComponent<RejaScript>().Old)
                        {
                            interact[i].GetComponent<RejaScript>().SetDisable();
                        }
                        else
                        {
                            interact[i].GetComponent<RejaScript>().ChangeStatus();
                        }

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

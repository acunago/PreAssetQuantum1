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
    public Vector3 rotationAngle;

    public bool isTimmer;
    public float timmer;
    public float actTime;

    private Quaternion quatOrignal;

    private Color original;
    private DoorScript doorCall;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        //Movement.transform.rotation = Quaternion.Euler(Movement.transform.rotation.x, Movement.transform.rotation.y, 0);
        state = LeverState.DISABLED;
        quatOrignal = Movement.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (state == LeverState.ACTIVE)
        {
            Movement.transform.rotation = Quaternion.Slerp(Movement.transform.rotation, Quaternion.Euler(rotationAngle), 1f);
            Movement.transform.GetChild(0).GetComponent<Outline>().enabled = true;
            Movement.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (isTimmer)
            {
                actTime += Time.deltaTime;
                if (timmer <= actTime)
                {
                    state = LeverState.DISABLED;
                    actTime = 0;

                }
            }

        }
        else
        {
            Movement.transform.rotation = quatOrignal;
            Movement.transform.GetChild(0).GetComponent<Outline>().enabled = false;
            Movement.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void SetActive()
    {
        if (state == LeverState.ACTIVE)
        {
            state = LeverState.DISABLED;
            

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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sALIO");
    }
}

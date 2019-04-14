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
    public GameObject interact;
    public LeverState state;

    private DoorScript doorCall;
    // Start is called before the first frame update
    void Start()
    {
        state = LeverState.DISABLED;
        if (interact.layer == 11)
        {
            doorCall = interact.GetComponent<DoorScript>();

        }
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
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.grey;
            doorCall.SetDisabled();

        }
        else
        {
            state = LeverState.ACTIVE;
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.red;


            doorCall.SetActive();

        }
    }
}

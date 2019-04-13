using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DoorState
{
    ACTIVE,
    DISABLED
}

public class DoorScript : MonoBehaviour
{
    public GameObject objetoManager;
    private DoorState state;
    // Start is called before the first frame update
    void Start()
    {
        state = DoorState.DISABLED;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActive()
    {
        state = DoorState.ACTIVE;

    }
    public void SetDisabled()
    {
        state = DoorState.DISABLED;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FrankState
{
    ACTIVE,
    DISABLED
}

public class FrankScript : MonoBehaviour
{

    private FrankState state;
    // Start is called before the first frame update
    void Start()
    {
        state = FrankState.DISABLED;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActive()
    {
        if (state == FrankState.ACTIVE)
            state = FrankState.ACTIVE;
        else
            state = FrankState.DISABLED;
    }

}

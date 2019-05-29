using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireState
{
    ACTIVE,
    DISABLED
}

public class FireScript : MonoBehaviour
{
    public FireState state;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetActive()
    {
        if (state == FireState.ACTIVE)
        {
            state = FireState.DISABLED;
        }
        else
        {
            state = FireState.ACTIVE;
        }

    }
}

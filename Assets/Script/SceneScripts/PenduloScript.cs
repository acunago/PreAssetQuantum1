using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PenduloState
{
    ACTIVE,
    DISABLED
}

public class PenduloScript : MonoBehaviour
{
    public PenduloState state;
    private float i;
    // Start is called before the first frame update
    void Start()
    {
        state = PenduloState.ACTIVE;
    }

    // Update is called once per frame
    void Update()
    {

        if(state == PenduloState.ACTIVE)
        {
            i += Time.deltaTime;
            transform.Rotate(new Vector3(0, 0,  Mathf.Sin(i)));

        }
        else
        {
            i = 0;
        }
    }
}

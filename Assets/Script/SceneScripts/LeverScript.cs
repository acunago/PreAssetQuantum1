using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum LeverState
{
    ACTIVE,
    DISABLED
}
public class LeverScript : MonoBehaviour
{
    private LeverState state;
    // Start is called before the first frame update
    void Start()
    {
        state = LeverState.DISABLED;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive()
    {
        state = LeverState.ACTIVE;

    }
    public void SetDisabled()
    {
        state = LeverState.DISABLED;

    }
}

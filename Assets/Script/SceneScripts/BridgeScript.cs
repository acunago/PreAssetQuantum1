using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BridgeState
{
    ACTIVE,
    DISABLED
}

public class BridgeScript : MonoBehaviour
{
    public GameObject objetoManager;
    public BridgeState state;
    public Vector3 rotationAngle;
    public bool canRotate;
    Quaternion auxV3;
    // Start is called before the first frame update
    void Start()
    {
        state = BridgeState.DISABLED;
        auxV3 = transform.rotation;
    }
    private void Update()
    {
        if (canRotate)
        {
            if (state == BridgeState.ACTIVE)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotationAngle),01);
            }
        }
    }
    public void SetActive()
    {
        state = BridgeState.ACTIVE;
        transform.rotation = Quaternion.Euler(rotationAngle);
    }
    public void SetDisabled()
    {
        state = BridgeState.DISABLED;
        transform.rotation = auxV3;
    }
}

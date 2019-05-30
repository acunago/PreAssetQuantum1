using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorState
{
    ACTIVE,
    DISABLED
}

public class DoorScript : MonoBehaviour
{
    public GameObject objetoManager;
    public DoorState state;
    public int rotationAngle;
    public SoundBag snd;
    private Quaternion rotation;
    Vector3 auxV3;

    // Start is called before the first frame update
    void Start()
    {
        state = DoorState.DISABLED;
        auxV3 = new Vector3(0, 90 * rotationAngle, 0);
    }

    // Update is called once per frame

    public void SetActive()
    {
        //state = DoorState.ACTIVE;
        transform.Rotate(auxV3);


    }
    public void SetDisabled()
    {
        //state = DoorState.DISABLED;
        transform.Rotate(-auxV3);


    }
}

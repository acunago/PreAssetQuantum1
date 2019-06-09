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
    Vector3 initial;

    // Start is called before the first frame update
    void Start()
    {
        state = DoorState.DISABLED;
        auxV3 = new Vector3(0,  rotationAngle, 0);
        rotation = transform.rotation;
    }

    private void Update()
    {
        if (state == DoorState.ACTIVE)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(auxV3), 0.05f);
            
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.05f);
        }
    }

    // Update is called once per frame

    public void SetActive()
    {
        snd.PlaySound(0);
        state = DoorState.ACTIVE;
        //transform.Rotate(auxV3);
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(auxV3), 1f);

    }
    public void SetDisabled()
    {
        snd.PlaySound(1);
        state = DoorState.DISABLED;
        //transform.Rotate(-auxV3);
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-auxV3), 1f);

    }
}

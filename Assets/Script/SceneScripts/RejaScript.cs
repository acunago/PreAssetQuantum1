using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RejaState
{
    ACTIVE,
    DISABLED
}
public class RejaScript : MonoBehaviour
{
    public RejaState state;
    public GameObject Origen;
    public GameObject fin;
    public GameObject Collider;
    public SoundBag snd;

    public bool Old = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (state == RejaState.ACTIVE)
        {
            transform.position = Vector3.Lerp(transform.position, fin.transform.position, 0.1f);

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Origen.transform.position, 0.1f);

        }
    }

    public void ChangeStatus()
    {


        if (state == RejaState.ACTIVE)
        {
            state = RejaState.DISABLED;
        }
        else
        {
            state = RejaState.ACTIVE;
        }


    }

    public void SetActive()
    {



            state = RejaState.ACTIVE;
        



    }

    public void SetDisable()
    {
        state = RejaState.DISABLED;
        if (snd != null)
        {
            snd.PlaySound();
        }
    }
}

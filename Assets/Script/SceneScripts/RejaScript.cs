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
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (state == RejaState.ACTIVE)
        {
            transform.position = Vector3.Lerp(transform.position, fin.transform.position, 0.1f);
            Collider.SetActive(true);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Origen.transform.position, 0.1f);
            Collider.SetActive(false);
        }
    }

    public void SetActive()
    {
        Debug.Log("Entramos");
        if (state == RejaState.ACTIVE)
        {
            state = RejaState.DISABLED;


        }
        else
        {

            state = RejaState.ACTIVE;
        }

    }
}

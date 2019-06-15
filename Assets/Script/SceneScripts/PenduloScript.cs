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
    public SoundBag snd;
    public float  invert = 1;
    public float angleRot = 90;
    Quaternion angle;
    // Start is called before the first frame update
    void Start()
    {
        state = PenduloState.ACTIVE;
        angle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if(state == PenduloState.ACTIVE)
        {
            i += Time.deltaTime;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, invert * 90 * Mathf.Sin(i)));
            //transform.Rotate(new Vector3(0, 0,  Mathf.Sin(i)));


            if (Mathf.Sin(i) >= -0.1 && Mathf.Sin(i) <= 0.1)
            {
                snd.PlaySound();
                Debug.Log("pendulo movimiento");
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,0,90)),0.1f);
            i = 0;
        }
    }
    public void SetActive()
    {
        if (state == PenduloState.ACTIVE)
        {
            state = PenduloState.DISABLED;
            

        }
        else
        {
            
            state = PenduloState.ACTIVE;
        }
    }
}

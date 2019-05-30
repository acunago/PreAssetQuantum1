using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject interact;
    public int objects;
    public float objectsToChange = 1;
    public Color keepColour;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (objects >= objectsToChange)
        {

            interact.SetActive(false);

        }
        else
        {
            interact.SetActive(true);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 9)
        {
            objects = objects + 1;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer != 9)
        {
            objects = objects - 1;

        }
    }
}

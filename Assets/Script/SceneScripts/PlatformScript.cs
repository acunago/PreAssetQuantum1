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
    void Start()
    {
        
        keepColour = GetComponent<Renderer>().material.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (objects >= objectsToChange)
        {
            Renderer rend = GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("_Color");
            rend.material.color = Color.blue;
            interact.SetActive(false);

        }
        else
        {

            Renderer rend = GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("_Color");
            interact.SetActive(true);
            rend.material.color = keepColour;
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

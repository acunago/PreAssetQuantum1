using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public int objects;
    public float objectsToChange = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (objects >= objectsToChange)
        {
            Renderer rend = GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("_Color");
            rend.material.color = Color.blue;

        }
        else
        {

            Renderer rend = GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("_Color");
            rend.material.color = Color.green;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        objects = objects + 1;

    }
    private void OnCollisionExit(Collision collision)
    {

        objects = objects - 1;
    }
}

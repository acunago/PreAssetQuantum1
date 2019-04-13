using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.blue);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.green);

        }
    }
}

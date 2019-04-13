using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHead : MonoBehaviour
{
    private HeroBody hb;
    // Start is called before the first frame update
    void Start()
    {
        hb = transform.GetComponent<HeroBody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float left;
        float up;
        Vector3 vtr3 = Vector3.zero;


        left = Input.GetAxis("Horizontal");
        up = Input.GetAxis("Vertical");
        vtr3 = new Vector3(left,0, up);
        hb.Move(vtr3);
        PressKey();

    }

    private void PressKey() {

        if (Input.GetKeyDown(KeyCode.Space))

        {
            hb.Jump();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hb.Big();

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hb.Small();

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hb.Normal();

        }
        if (Input.GetMouseButtonDown(0))
        {
            hb.Activate();

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHead : MonoBehaviour
{
    private HeroBody hb;
    public Text txtClick;
    public float distanceObjects = 5f;
    // Start is called before the first frame update
    void Start()
    {
        txtClick.gameObject.SetActive(false);
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
        vtr3 = new Vector3(left, 0, up);
        hb.Move(vtr3);
        PressKey();

    }

    private void PressKey()
    {
        RaycastHit hit;
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

        if (hb.actions == Comport.CARGANDO)
        {
            if (Input.GetMouseButtonDown(0))
            {

                hb.SoltarCaja();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceObjects, Color.yellow);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceObjects))
            {
                if (hit.transform.gameObject.layer == 10)
                {
                    txtClick.gameObject.SetActive(true);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (hb.actions != Comport.CARGANDO)

                    {
                        hb.Activate(hit);
                        txtClick.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                txtClick.gameObject.SetActive(false);
            }
        }

    }
}

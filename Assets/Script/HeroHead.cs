using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHead : MonoBehaviour
{
    private HeroBody hb;
    public Text txtClick;
    public float distanceObjects = 5f;
    public Camera cam;
    public bool camChange = false;
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

        if (CameraManager.instance.camVar == CameraType.THIRD)
        {
            hb.Move(vtr3, cam.transform);
        }
        else
        {
            
            hb.Move(vtr3,cam);
        }
        PressKey();
        CheckVision();
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

        if (Input.GetMouseButtonDown(0))
        {
            if (hb.actions == Comport.CARGANDO)
            {
                hb.SoltarCaja();
            }
            else
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceObjects))
                {
                    hb.Activate(hit);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            CameraManager.instance.camVar = CameraType.FIRST;
        }

        if (Input.GetMouseButtonUp(1))
        {
            CameraManager.instance.camVar = CameraType.THIRD;
        }
    }
    public void CheckVision()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceObjects, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceObjects))
        {
            if (hit.transform.gameObject.layer != 9)
            {
                if (hit.transform.gameObject.layer == 10 && hb.state != transformations.GIGANT)
                {
                    txtClick.gameObject.SetActive(false);
                }
                else
                {
                    txtClick.gameObject.SetActive(true);
                }
            }
            else {
                txtClick.gameObject.SetActive(false);
            }
            Debug.Log(hit.transform.gameObject.layer);
        }
        else
        {
            txtClick.gameObject.SetActive(false);
        }

    }
}

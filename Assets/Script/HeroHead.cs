using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum transformations
{
    GIGANT,
    NORMAL,
    SMALL

}

public class HeroHead : MonoBehaviour
{
    [Header("Control")]
    public transformations state = transformations.NORMAL;

    public GameObject big;
    public GameObject small;
    public GameObject normal;


    private HeroBody hb;
    private HeroBodyBig hbBig;
    private HeroBodySmall hbSmall;

    public Text txtClick;
    public float distanceObjects = 5f;
    public Camera cam;

    public GameObject CamManager;
    

    // Start is called before the first frame update
    void Start()
    {
        txtClick.gameObject.SetActive(false);


        switch (state)
        {
            case transformations.GIGANT:
                hbBig = transform.GetComponent<HeroBodyBig>();
                break;
            case transformations.NORMAL:
                hb = transform.GetComponent<HeroBody>();
                break;
            case transformations.SMALL:
                hbSmall = transform.GetComponent<HeroBodySmall>();
                break;
            default:
                break;
        }

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

        switch (state)
        {
            case transformations.GIGANT:
                hbBig.Move(vtr3, cam.transform);
                PressKeyBig();
                CheckVision();
                break;
            case transformations.NORMAL:
                hb.Move(vtr3, cam.transform);
                PressKey();
                CheckVision();
                break;
            case transformations.SMALL:
                hbSmall.Move(vtr3, cam.transform);
                PressKeySmall();
                break;
            default:
                break;
        }


    }

    #region Buttons
    private void PressKey()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hb.Jump();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Big();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Small();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Normal();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hb.actions == Comport.CARGANDO)
            {
                //hb.SoltarCaja();
            }
            else
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceObjects))
                {
                    hb.Activate(hit);
                }
            }
        }
    }

    private void PressKeyBig()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Big();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Small();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Normal();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hbBig.actions == Comport.CARGANDO)
            {
                hbBig.SoltarCaja();
            }
            else
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceObjects))
                {
                    hbBig.Activate(hit);
                }
            }
        }
    }

    private void PressKeySmall()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hbSmall.Jump();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Big();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Small();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Normal();
        }

    }
    #endregion


    public void CheckVision()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceObjects, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceObjects))
        {
            if (hit.transform.gameObject.layer != 9)
            {
                if (hit.transform.gameObject.layer == 10 && state != transformations.GIGANT)
                {
                    txtClick.gameObject.SetActive(false);
                }
                else
                {
                    txtClick.gameObject.SetActive(true);
                }
            }
            else
            {
                txtClick.gameObject.SetActive(false);
            }
            Debug.Log(hit.transform.gameObject.layer);
        }
        else
        {
            txtClick.gameObject.SetActive(false);
        }

    }

    #region transformations
    public void Big()
    {
        if (state != transformations.GIGANT)
        {
            CameraManager.instance.state = transformations.GIGANT;
            big.transform.position = this.transform.position;
            big.gameObject.SetActive(true);
            small.gameObject.SetActive(false);
            normal.gameObject.SetActive(false);


        }
    }
    public void Small()
    {
        if (state != transformations.SMALL)
        {
            CameraManager.instance.state = transformations.SMALL;
            small.transform.position = this.transform.position;
            small.gameObject.SetActive(true);
            normal.gameObject.SetActive(false);
            big.gameObject.SetActive(false);

        }
    }
    public void Normal()
    {
        if (state != transformations.NORMAL)
        {
            CameraManager.instance.state = transformations.NORMAL;
            normal.transform.position = this.transform.position;
            normal.gameObject.SetActive(true);
            small.gameObject.SetActive(false);
            big.gameObject.SetActive(false);
        }

    }
    #endregion



}

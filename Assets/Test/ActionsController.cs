using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ActionsController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject red;
    public GameObject blue;
    public GameObject puntoDisparo;
    public float i = 1;
    public float arrowSpeed = 100;
    public float distanceCheck = 8;
    GameObject redMagnet;
    GameObject blueMagnet;
    public bool atract;

    public GameObject crossHair;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MagnetsController blueScript;
        MagnetsController redScript;

        if (Input.GetMouseButtonDown(0))
        {
            if (i == 1)
            {
                if (redMagnet != null)
                {
                    redMagnet.GetComponent<MagnetsController>().DestroyObj();
                    atract = false;
                }
                redMagnet = CreateBox(red);
                i = i + 1;

            }
            else
            {
                if (blueMagnet != null)
                {
                    blueMagnet.GetComponent<MagnetsController>().DestroyObj();
                    atract = false;
                }
                blueMagnet = CreateBox(blue);
                i = 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (redMagnet != null && blueMagnet != null)
            {
                blueScript = blueMagnet.GetComponent<MagnetsController>();
                redScript = redMagnet.GetComponent<MagnetsController>();
                if (blueScript.Stick && redScript.Stick)
                {
                    RaycastHit hit;
                    if (Physics.Linecast(redMagnet.transform.position, (redMagnet.transform.position - blueMagnet.transform.position).normalized * distanceCheck, out hit))
                    {
                        Debug.Log("hit.transform.gameObject.layer " + hit.transform.gameObject.layer);

                            Debug.Log("pego");
                            atract = true;

    
                    }
                    else
                    {
                        atract = false;
                    }
                }
                else
                {
                    atract = false;
                }
            }
            else
            {
                atract = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (redMagnet != null)
            {
                redMagnet.GetComponent<MagnetsController>().DestroyObj();
                atract = false;
            }
            if (blueMagnet != null)
            {
                blueMagnet.GetComponent<MagnetsController>().DestroyObj();
                atract = false;
            }
            atract = false;
        }

        if (atract)
        {
            if (redMagnet == null || blueMagnet == null)
            {
                atract = false;
                return;
            }

            Rigidbody rbBlue = blueMagnet.GetComponent<FixedJoint>().connectedBody;
            Rigidbody rbRed = redMagnet.GetComponent<FixedJoint>().connectedBody;


            Vector3 _direction = 2 * (blueMagnet.transform.position - redMagnet.transform.position);
            Vector3 _force = _direction.normalized * arrowSpeed;

            rbBlue.transform.GetComponent<Rigidbody>().AddForce(-_force, ForceMode.Impulse);
            rbRed.transform.GetComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);

        }
    }

    public GameObject CreateBox(GameObject cube)
    {
        RaycastHit rayCross;

        Vector3 fwd =  crossHair.transform.position- puntoDisparo.transform.position;

        if (Physics.Raycast(puntoDisparo.transform.position, fwd, 10))
        {
            
        }
        GameObject arrow = Instantiate(cube, puntoDisparo.transform.position, transform.rotation);
        Vector3 _direction = 2 * fwd;
        Vector3 _force = _direction.normalized * arrowSpeed;

        arrow.transform.GetComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);
        return arrow;
                    
    }
}

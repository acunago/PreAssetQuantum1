using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public enum MySounds : int
{
    disparo = 0,
    cajas = 1,
    init = 2,
}

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

    public GameObject PosTotal;
    public GameObject crossHair;
    public RectTransform cross;

    public Camera cam;

    private bool playerClose = false;
    public bool attached = false;

    public List<AudioClip> sounds = new List<AudioClip>();
    public AudioManager AudManager;
    // Start is called before the first frame update
    void Awake()
    {
        AudManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void Start()
    {
        AudManager.PlaySound(sounds[(int)MySounds.init]);
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(cross.localPosition.x, cross.localPosition.y, 0));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        //Debug.DrawLine(transform.position,  Camera.main.ScreenToWorldPoint(crossHair.transform.forward) * 8);
        if (PosTotal != null)
        {
            if (attached)
            {
                transform.position = Vector3.Lerp(transform.position, PosTotal.transform.position, 0.15f);
                transform.rotation = Quaternion.Lerp(transform.rotation, PosTotal.transform.rotation, 0.15f);
                KeyPress();

            }
            else
            {
                if (playerClose)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        attached = true;
                    }

                }
            }
        }
    }
    public void KeyPress()
    {
        MagnetsController blueScript;
        MagnetsController redScript;

        if (Input.GetMouseButtonDown(1))
        {
            AudManager.PlaySound(sounds[(int)MySounds.disparo]);
            if (redMagnet != null)
            {
                redMagnet.GetComponent<MagnetsController>().DestroyObj();
                atract = false;
            }
            redMagnet = CreateBox(red);

            if (blueMagnet != null)
            {
                blueMagnet.transform.GetChild(4).GetChild(0).GetComponent<particleAttractorLinear>().target = redMagnet;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            AudManager.PlaySound(sounds[(int)MySounds.disparo]);
            if (blueMagnet != null)
            {
                blueMagnet.GetComponent<MagnetsController>().DestroyObj();
                atract = false;
            }
            blueMagnet = CreateBox(blue);

            if(redMagnet!= null)
            {
                blueMagnet.transform.GetChild(4).GetChild(0).GetComponent<particleAttractorLinear>().target = redMagnet;
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
        if (Input.GetKeyDown(KeyCode.Tab))
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

            if (rbBlue.transform.gameObject.layer == 18 || rbBlue.transform.gameObject.layer == 22)
            {

                Debug.Log("Deberia mover Azul");
                //rbBlue.AddForce(-_force, ForceMode.Impulse);
                //rbBlue.transform.position  = Vector3.Lerp (rbRed.transform.position, (rbRed.transform.position - rbBlue.transform.position).normalized,1f);

                InteractOrbs(rbBlue.gameObject, rbRed.gameObject);


            }
            else
            {
                //if (rbRed.transform.gameObject.layer == 18 || rbRed.transform.gameObject.layer == 22)
                //{

                //    InteractOrbs(rbRed.gameObject, rbBlue.gameObject);

                //}
            }

            //if (rbBlue.transform.gameObject.layer == 18)
            //{

            //    Debug.Log("Deberia mover Azul");
            //    //rbBlue.AddForce(-_force, ForceMode.Impulse);
            //    //rbBlue.transform.position  = Vector3.Lerp (rbRed.transform.position, (rbRed.transform.position - rbBlue.transform.position).normalized,1f);
            //    if (Vector3.Distance(rbBlue.transform.position, rbRed.transform.position) > 2f)
            //    {
            //        rbBlue.transform.position = Vector3.MoveTowards(rbBlue.transform.position, rbRed.transform.position, 2f * Time.deltaTime);
            //    }
            //    //rbBlue.MovePosition((rbRed.transform.position - rbBlue.transform.position).normalized  *  Time.deltaTime);

            //}

        }
    }




    private void InteractOrbs(GameObject atractObj, GameObject to)
    {
        if (atractObj.transform.gameObject.layer == 18)
        {

            Debug.Log("Deberia mover Azul");
            //rbBlue.AddForce(-_force, ForceMode.Impulse);
            //rbBlue.transform.position  = Vector3.Lerp (rbRed.transform.position, (rbRed.transform.position - rbBlue.transform.position).normalized,1f);
            if (Vector3.Distance(atractObj.transform.position, to.transform.position) > 2f)
            {
                atractObj.transform.position = Vector3.MoveTowards(atractObj.transform.position, to.transform.position, 2f * Time.deltaTime);
                if (Vector3.Distance(atractObj.transform.position, to.transform.position) > 2f)
                {
                    if (atractObj.transform.GetComponent<SoundBag>() != null)
                    {
                        atractObj.transform.GetComponent<SoundBag>().PlaySound();
                    }

                }
                else
                {
                    atractObj.transform.GetComponent<SoundBag>().StopSound();
                }
            }
            //rbBlue.MovePosition((rbRed.transform.position - rbBlue.transform.position).normalized  *  Time.deltaTime);

        }

        if (atractObj.transform.gameObject.layer == 22)
        {
            atractObj.transform.parent.GetComponent<LeverScript>().SetActive();


            atract = false;


        }

    }

    public GameObject CreateBox(GameObject cube)
    {

        Ray ray = cam.ScreenPointToRay(cross.position);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        //Vector3 fwd = Camera.main.ScreenToWorldPoint(crossHair.transform.position) - puntoDisparo.transform.forward  ;
        Vector3 fwd = Camera.main.ScreenToWorldPoint(crossHair.transform.position) + puntoDisparo.transform.position  ;

        GameObject arrow = Instantiate(cube, puntoDisparo.transform.position, transform.rotation);
        Vector3 _direction = 2 * fwd;
        Vector3 _force = fwd.normalized * arrowSpeed;

        arrow.transform.GetComponent<Rigidbody>().AddForce(ray.direction * arrowSpeed, ForceMode.Impulse);
        return arrow;

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == 8)
        {
            playerClose = true;
        }
    }
}

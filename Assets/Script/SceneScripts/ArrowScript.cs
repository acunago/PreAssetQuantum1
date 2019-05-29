using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArrowState
{
    ACTIVE,
    DISABLED
}

public class ArrowScript : MonoBehaviour
{
    public ArrowState state;
    public GameObject Arrow;
    public float destroyArrow = 5;
    public float vel = 5;
    public float time = 1;
    public float auxTime;

    // Start is called before the first frame update
    void Start()
    {
        Arrow.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        state = ArrowState.DISABLED;
        auxTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if(state == ArrowState.ACTIVE)
        {
            auxTime += Time.deltaTime;
            if (auxTime > 0.3f)
            {
                Arrow.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                Arrow.transform.GetComponent<Rigidbody>().isKinematic = false;
                Arrow.transform.GetComponent<Rigidbody>().AddForce(Arrow.transform.forward * vel);
                Destroy(gameObject, destroyArrow);
                Destroy(Arrow, destroyArrow);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {

            state = ArrowState.ACTIVE;

        }
    }
}

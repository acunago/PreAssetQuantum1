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
    // Start is called before the first frame update
    void Start()
    {
        state = ArrowState.DISABLED;
    }

    // Update is called once per frame
    void Update()
    {
      if(state == ArrowState.ACTIVE)
        {
            Arrow.transform.GetComponent<Rigidbody>().isKinematic = false;
            Arrow.transform.GetComponent<Rigidbody>().AddForce(Arrow.transform.forward * 5);
            Destroy(gameObject, destroyArrow);
            Destroy(Arrow, destroyArrow);
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

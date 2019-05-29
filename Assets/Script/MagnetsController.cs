using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetsController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Stick = false;
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
        if(collision.gameObject.layer == 2) { return; }
        if (collision.transform.GetComponent<Rigidbody>() != null)
        {

                var sticky = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                sticky.connectedBody = collision.rigidbody;
                Stick = true;
        
        }
        else
        {
            DestroyObj();
        }

        //if (collision.collider != null && collision.collider.gameObject.GetComponent<Emerald_AI>() != null)
        //{
        //    collision.collider.gameObject.GetComponent<Emerald_AI>().Damage(100, Emerald_AI.TargetType.Player);

        //}

    }
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloorScript : MonoBehaviour
{
    public GameObject rtnPoint;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = rtnPoint.transform.position;
    }
}

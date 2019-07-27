using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScript : MonoBehaviour
{
    public GameObject[] activeObjects;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in activeObjects)
        {
            if(item.gameObject.layer == 23 || item.gameObject.layer == 26)
            {
                item.GetComponent<RejaScript>().ChangeStatus();
            }
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (var item in activeObjects)
        {
            if (item.gameObject.layer == 23 || item.gameObject.layer == 26)
            {
                item.GetComponent<RejaScript>().ChangeStatus();
            }
        }
    }
}

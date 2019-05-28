using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrapScript : MonoBehaviour
{
    public GameObject trap;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8) { 
            ActiveChild();
        }
    }

    private void ActiveChild()
    {
        if (trap != null)
        {
            for (int i = 0; i < trap.transform.childCount; i++)
            {
                trap.transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;
                trap.transform.GetChild(i).GetComponent<Collider>().isTrigger = false;
            }
            trap.transform.GetComponent<Rigidbody>().useGravity = true;
            RemoveObj();
        }
    }
    public void RemoveObj()
    {
        Destroy(trap, 3f);
    }
}

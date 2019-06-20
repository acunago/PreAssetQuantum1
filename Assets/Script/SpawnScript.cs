using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.layer == 8)
        {
            if(gameManager.GetComponent<GameScript>() != null)
            {
                gameManager.GetComponent<GameScript>().checkpoint = gameObject;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffScript : MonoBehaviour
{
    public List<GameObject> turnON;
    public List<GameObject> turnOFF;
    public SoundBag snd;
    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject go in turnON)
        {

            go.SetActive(true);
        }

        foreach (GameObject go in turnOFF)
        {
            go.SetActive(false);
        }
        snd.PlaySound();
        this.gameObject.SetActive(false);
    }
}

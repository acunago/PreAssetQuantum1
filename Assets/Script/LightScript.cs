using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public float minInt = 4;
    public float maxInt = 6;
    public float speed = 1;

    float timer;
    int flip;

    Light lg;

    void Start()
    {
        lg = GetComponent<Light>();

        timer = 0;

        flip = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > speed)
        {
            timer = 0;
            lg.intensity = Mathf.Lerp(minInt, maxInt, flip);
            flip = (flip == 0) ? 1 : 0;

        }
    }
}

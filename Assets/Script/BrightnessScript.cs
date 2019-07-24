using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessScript : MonoBehaviour
{
    public void SetBrightness(float _value)
    {
        RenderSettings.ambientLight = new Color(_value, _value, _value, 1f);
    }
}

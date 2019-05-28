using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LanzallamaState
{
    ACTIVE,
    DISABLED
}
public class LanzallamasScript : MonoBehaviour
{
    public LanzallamaState state;
    public GameObject fire;
    // Start is called before the first frame update

    public void ActiveTrap()
    {
        if (state == LanzallamaState.DISABLED)
        {
            state = LanzallamaState.ACTIVE;
            fire.gameObject.SetActive(true);
        }
        else
        {
            state = LanzallamaState.DISABLED;
            fire.gameObject.SetActive(false);
        }
    }
}

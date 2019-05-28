using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Help
{
    Active,
    Disable
}
public class HelpUIScript : MonoBehaviour
{
    public Help state = Help.Disable;
    public Image helpImage;
    public float destroyImage = 3f;
    public float timeGradient = 0.25f;
    
    private float HelpDestroy;
    private float gradient;
    // Start is called before the first frame update
    void Start()
    {
        var tempColor = helpImage.color;
        tempColor.a = 0;
        helpImage.color = tempColor;

        helpImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(state == Help.Active)
        {

            if(HelpDestroy >= destroyImage)
            {
                var tempColor = helpImage.color;
                tempColor.a = gradient;
                if (gradient >= 0)
                {
                    gradient = gradient - timeGradient * Time.deltaTime;
                }
                helpImage.color = tempColor;

                Destroy(this, destroyImage);
            }
            else
            {
                helpImage.gameObject.SetActive(true);

                var tempColor = helpImage.color;
                tempColor.a = gradient;
                if (gradient < 1)
                {
                    gradient = gradient + timeGradient * Time.deltaTime;
                }
                helpImage.color = tempColor;
                HelpDestroy += Time.deltaTime;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        state = Help.Active;
        
    }
}

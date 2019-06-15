using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DialogEnter
{
    enable,
    disable
}
public class DialogManager : MonoBehaviour
{
    public Image dialog;
    public Image avatarImage;
    public Text output;
    [TextArea(3, 10)]
    public string text;
    public bool wasActive = false;


    public float timeGradient = 0.25f;
    public float timeOnScreen = 2f;
    private float HelpDestroy;
    private float gradient;
    private float gradientText;
    public DialogEnter status = DialogEnter.disable;
    
    // Start is called before the first frame update
    void Start()
    {
        var tempColor = dialog.color;
        tempColor.a = 0;
        dialog.color = tempColor;
        avatarImage.color = tempColor;
        output.color = tempColor;
        dialog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(status == DialogEnter.enable)
        {
            wasActive = true;
            dialog.gameObject.SetActive(true);

            var tempColor = dialog.color;

            if (gradient <= timeOnScreen)
            {
                tempColor.a = gradient;
                gradient = gradient + timeGradient * Time.deltaTime;
                dialog.color = tempColor;
                avatarImage.color = tempColor;
                output.color = tempColor;
            }
            else
            {

                status = DialogEnter.disable;

                
                
            }



        }
        else
        {
            if (wasActive)
            {
                var tempColor = dialog.color;
                if (gradient >= 0)
                {
                    Debug.Log("destroy");
                    tempColor.a = gradient;
                    gradient = gradient - timeGradient * Time.deltaTime;
                    dialog.color = tempColor;
                    avatarImage.color = tempColor;
                    output.color = tempColor;

                }

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8 && !wasActive)
        {

            status = DialogEnter.enable;
            output.text = text;
        }
    }

}

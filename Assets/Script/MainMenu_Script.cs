using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{
    public Transform currentPos, startPos, optionsPos, playPos, instructionsPos, enterDoorPos;
    public float speedFactor = 0.1f;
    private float delayWait = 0f;
    private float goDoor = 2f;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentPos.position, speedFactor);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, currentPos.rotation, speedFactor);

        if(currentPos == playPos)
        {
            delayWait += 1 * Time.deltaTime;
            Debug.Log(delayWait);
            if(delayWait >= goDoor)
            {
                delayWait = 0;
                Move_5();
                speedFactor = 0.001f;
            }

        }


    }

    public void Move_5()
    {
        currentPos = enterDoorPos;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level1-TheCave");
    }

    public void Move_1()
    {
        currentPos = startPos;
    }

    public void Move_2()
    {
        currentPos = optionsPos;
    }

    public void Move_3()
    {
        currentPos = playPos;
    }

    public void Move_4()
    {
        currentPos = instructionsPos;
    }

    

    public void Quit()
    {
        Application.Quit();
    }


}

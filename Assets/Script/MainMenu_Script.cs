﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{
    public Transform currentPos, startPos, optionsPos, playPos, instructionsPos;
    public float speedFactor = 0.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos.position, speedFactor);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, currentPos.rotation, speedFactor);
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

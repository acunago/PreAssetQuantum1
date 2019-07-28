using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{

    public List<AudioClip> allSounds;
    public Transform currentPos, startPos, optionsPos, playPos, instructionsPos, enterDoorPos;
    public float speedFactor = 0.1f;
    private float delayWait = 0f;
    private float delayGo = 0f;

    private float goDoor = 2f;
    private float goScene = 2f;
    private AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
                currentPos = enterDoorPos;
                speedFactor = 0.005f;
                delayGo += 1 * Time.deltaTime;
                Debug.Log(delayGo);

            }

        }

        if (Vector3.Distance(enterDoorPos.position, transform.position) < 1)
        {
            StartLevel();
        }
    }

    public void Move_5()
    {
        audioSource.clip = allSounds[0];
        audioSource.Play();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level1-TheCave");
    }

    public void Move_1()
    {
        audioSource.clip = allSounds[0];
        audioSource.Play();
        currentPos = startPos;
    }

    public void Move_2()
    {
        audioSource.clip = allSounds[0];
        audioSource.Play();
        currentPos = optionsPos;
    }

    public void Move_3()
    {
        audioSource.clip = allSounds[0];
        audioSource.Play();
        currentPos = playPos;
    }

    public void Move_4()
    {
        audioSource.clip = allSounds[0];
        audioSource.Play();
        currentPos = instructionsPos;
    }

    

    public void Quit()
    {
        audioSource.clip = allSounds[0];
        audioSource.Play();
        Application.Quit();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public float time;

    void Start(){
        Invoke("Restart", time);
    }
    public void Restart(){
        SceneManager.LoadScene("MainMenu");
        
    }
    
}
